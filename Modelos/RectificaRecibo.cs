using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceptos.Modelos
{
    public class RectificaRecibo
    {
        public DateTime Fecha { get; set; }
        public string serie { get; set; }
        public int recibo { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public  decimal IVA { get; set; }

        public decimal esclavo { get; set; }

        public decimal diferencia { get; set; }

        public string cancelado { get; set; }

    }
}
