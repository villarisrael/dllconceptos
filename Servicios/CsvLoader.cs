using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using conceptos.Modelos;
using Microsoft.VisualBasic.FileIO;

public static class CsvLoader
{
    public static List<VCuotaUsoDetalle> CargarDesdeCsv(string rutaCsv)
    {
        var lista = new List<VCuotaUsoDetalle>();

        using (TextFieldParser parser = new TextFieldParser(rutaCsv))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(","); // separador CSV
            parser.HasFieldsEnclosedInQuotes = true;

            bool isFirst = true;

            while (!parser.EndOfData)
            {
                string[] campos = parser.ReadFields();

                if (isFirst)
                {
                    isFirst = false; // saltar encabezado
                    continue;
                }

                if (campos.Length < 16) continue;

                try
                {
                    var item = new VCuotaUsoDetalle
                    {
                        Fecha = DateTime.ParseExact(campos[0], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        CLAVE = int.Parse(campos[1]),
                        USO = campos[2],
                        ID_TARIFA = int.Parse(campos[3]),
                        DESCRIPCION_CUOTA = campos[4],
                        Medido = campos[5] == "1",
                        SERIE = campos[6],
                        RECIBO = int.Parse(campos[7]),
                        SUBTOTAL = decimal.Parse(campos[8], CultureInfo.InvariantCulture),
                        IVA = decimal.Parse(campos[9], CultureInfo.InvariantCulture),
                        TOTAL = decimal.Parse(campos[10], CultureInfo.InvariantCulture),
                        numconcepto = int.Parse(campos[11]),
                        monto = decimal.Parse(campos[12], CultureInfo.InvariantCulture),
                        concepto = campos[13],
                        cuentausuario = int.Parse(campos[14]),
                        rubro = campos[15],
                        CuentaN5 = campos.Length > 16 ? campos[16] : null,
                        llevaiva = campos.Length > 17 ? int.Parse(campos[17]) : 0
                    };

                    lista.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en línea CSV: " + ex.Message);
                }
            }
        }

        return lista;
    }
}

