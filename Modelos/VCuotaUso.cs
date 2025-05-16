using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceptos.Modelos
{
    public class VCuotaUso
    {
        public DateTime Fecha { get; set; }
        public int CLAVE { get; set; }
        public string USO { get; set; }
        public int ID_TARIFA { get; set; }

        public int Medido { get;set; }
        public string DESCRIPCION_CUOTA { get; set; }
        public string SERIE { get; set; }
        public int RECIBO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal IVA { get; set; }
        public decimal TOTAL { get; set; }
    }


}
