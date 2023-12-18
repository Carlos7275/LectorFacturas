using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorFacturas.Modelos
{
    internal class FacturaDetalle
    {
        public string Version { get; set; }
        public string Folio { get; set; }
        public string RFCEmisor { get; set; }
        public string RFCReceptor { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string ValorUnitario { get; set; }
        public string Importe { get; set; }
        public string Fecha { get; set; }
        public string Base { get; set; }
        public string TasaOCuota { get; set; }
        public string ImporteIva { get; set; }
    }
}
