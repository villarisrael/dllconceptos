
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using conceptos.Clases;
using conceptos.Modelos;

namespace conceptos.Servicios
{
    public static class ExportadorCSV
    {
        private class RegistroContable
        {
            public string CuentaN5 { get; set; }
            public string Acumulativa { get; set; }
            public string Descripcion { get; set; }
            public decimal Monto { get; set; }
            public decimal IVA { get; set; }
            public bool LlevaIVA { get; set; }
        }

        public static void ExportarNivel4y5ACSV(List<VCuotaUsoDetalle> lista, List<Nivel4> nivel4, List<Nivel5> nivel5, DateTime desde, DateTime hasta, string rutaArchivoCsv)
        {
            foreach (var item in lista)
            {
                if (string.IsNullOrWhiteSpace(item.CuentaN5))
                {
                    item.CuentaN5 = TablaClasificacion.ObtenerCuentaN5(item.Medido, item.CLAVE, item.numconcepto, item.cuentausuario, item.rubro);
                }
            }

            var separados = new List<RegistroContable>();

            foreach (var item in lista)
            {
                var cuenta = item.CuentaN5;
                var acumulativa = nivel5.FirstOrDefault(n => n.CuentaN5 == cuenta)?.Acumulativa ?? "";
                var descripcion = nivel5.FirstOrDefault(n => n.CuentaN5 == cuenta)?.Descripcion ?? "";

                if (!string.IsNullOrWhiteSpace(cuenta))
                {
                    if (item.llevaiva > 0)
                    {
                        separados.Add(new RegistroContable
                        {
                            CuentaN5 = cuenta,
                            Acumulativa = acumulativa,
                            Descripcion = descripcion,
                            Monto = item.monto,
                            IVA = item.monto * 0.16M,
                            LlevaIVA = true
                        });
                    }
                    else
                    {
                        separados.Add(new RegistroContable
                        {
                            CuentaN5 = cuenta,
                            Acumulativa = acumulativa,
                            Descripcion = descripcion,
                            Monto = item.monto,
                            IVA = 0,
                            LlevaIVA = false
                        });
                    }
                }
            }

            var grupoIdentificadosConIVA = separados
                .Where(x => x.LlevaIVA)
                .GroupBy(x => new { x.CuentaN5, x.Acumulativa, x.Descripcion })
                .Select(g => new
                {
                    g.Key.CuentaN5,
                    g.Key.Acumulativa,
                    g.Key.Descripcion,
                    Monto = g.Sum(x => x.Monto),
                    IVA = g.Sum(x => x.IVA),
                    LlevaIVA = true
                })
                .ToList();

            var grupoIdentificadosSinIVA = separados
                .Where(x => !x.LlevaIVA)
                .GroupBy(x => new { x.CuentaN5, x.Acumulativa, x.Descripcion })
                .Select(g => new
                {
                    g.Key.CuentaN5,
                    g.Key.Acumulativa,
                    g.Key.Descripcion,
                    Monto = g.Sum(x => x.Monto),
                    IVA = g.Sum(x => x.IVA),
                    LlevaIVA = false
                })
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine("CUENTAS IDENTIFICADAS - CON IVA");
            sb.AppendLine("Cuenta Acumulativa,Descripción cuenta Acumulativa,Cuenta Detalle,Descripción Cuenta,Monto,IVA,LlevaIVA");

            foreach (var g in grupoIdentificadosConIVA)
            {
                sb.AppendLine($"{g.Acumulativa},{g.Descripcion},{g.CuentaN5},{g.Descripcion},{g.Monto.ToString("F2", CultureInfo.InvariantCulture)},{g.IVA.ToString("F2", CultureInfo.InvariantCulture)},Sí");
            }

            sb.AppendLine();
            sb.AppendLine("CUENTAS IDENTIFICADAS - SIN IVA");
            sb.AppendLine("Cuenta Acumulativa,Descripción cuenta Acumulativa,Cuenta Detalle,Descripción Cuenta,Monto,IVA,LlevaIVA");

            foreach (var g in grupoIdentificadosSinIVA)
            {
                sb.AppendLine($"{g.Acumulativa},{g.Descripcion},{g.CuentaN5},{g.Descripcion},{g.Monto.ToString("F2", CultureInfo.InvariantCulture)},{g.IVA.ToString("F2", CultureInfo.InvariantCulture)},No");
            }

            sb.AppendLine();
            sb.AppendLine("CONCEPTOS NO IDENTIFICADOS - CON IVA");
            sb.AppendLine("NumConcepto,Descripcion,Monto,IVA");

            var noIdentificadosConIVA = lista
                .Where(x => string.IsNullOrWhiteSpace(x.CuentaN5) && x.llevaiva > 0)
                .GroupBy(x => x.numconcepto)
                .Select(g => new
                {
                    NumConcepto = g.Key,
                    Concepto = g.First().concepto,
                    Monto = g.Sum(x => x.monto),
                    IVA = g.Sum(x => x.monto * 0.16M)
                });

            foreach (var item in noIdentificadosConIVA)
            {
                sb.AppendLine($"{item.NumConcepto},{item.Concepto},{item.Monto.ToString("F2", CultureInfo.InvariantCulture)},{item.IVA.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            sb.AppendLine();
            sb.AppendLine("CONCEPTOS NO IDENTIFICADOS - SIN IVA");
            sb.AppendLine("NumConcepto,Descripcion,Monto,IVA");

            var noIdentificadosSinIVA = lista
                .Where(x => string.IsNullOrWhiteSpace(x.CuentaN5) && x.llevaiva == 0)
                .GroupBy(x => x.numconcepto)
                .Select(g => new
                {
                    NumConcepto = g.Key,
                    Concepto = g.First().concepto,
                    Monto = g.Sum(x => x.monto),
                    IVA = 0
                });

            foreach (var item in noIdentificadosSinIVA)
            {
                sb.AppendLine($"{item.NumConcepto},{item.Concepto},{item.Monto.ToString("F2", CultureInfo.InvariantCulture)},{item.IVA.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            File.WriteAllText(rutaArchivoCsv, sb.ToString(), Encoding.UTF8);
        }
    }
}
