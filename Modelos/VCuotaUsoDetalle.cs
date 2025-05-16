using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceptos.Modelos
{
    public class VCuotaUsoDetalle
    {
        public DateTime Fecha { get; set; }
        public int CLAVE { get; set; }

        public int cuentausuario { get; set; }
        public string USO { get; set; }
        public int ID_TARIFA { get; set; }
        public string DESCRIPCION_CUOTA { get; set; }
        public bool Medido { get; set; }
        public string SERIE { get; set; }
        public int RECIBO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal IVA { get; set; }
        public decimal TOTAL { get; set; }
        public int numconcepto { get; set; }
        public decimal monto { get; set; }
       
        public string concepto { get; set; }

        public string rubro { get; set; }

        // Esta la obtendremos cruzando con la tabla en memoria
        public string CuentaN5 { get; set; }

        public int llevaiva { get; set; }
    }

}
