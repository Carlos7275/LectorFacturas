using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LectorFacturas.Modelos
{
    [XmlRoot("Comprobante", Namespace = "http://www.sat.gob.mx/cfd/4")]
    public class Comprobante4
    {
        [XmlAttribute("Version")]
        public string Version { get; set; }

        [XmlAttribute("Serie")]
        public string Serie { get; set; }

        [XmlAttribute("Folio")]
        public string Folio { get; set; }

        [XmlAttribute("Fecha")]
        public DateTime Fecha { get; set; }

        [XmlAttribute("Sello")]
        public string Sello { get; set; }

        [XmlAttribute("NoCertificado")]
        public string NoCertificado { get; set; }

        [XmlAttribute("Certificado")]
        public string Certificado { get; set; }

        [XmlAttribute("SubTotal")]
        public decimal SubTotal { get; set; }

        [XmlAttribute("Descuento")]
        public decimal Descuento { get; set; }

        [XmlAttribute("Moneda")]
        public string Moneda { get; set; }

        [XmlAttribute("Total")]
        public decimal Total { get; set; }

        [XmlAttribute("TipoDeComprobante")]
        public string TipoDeComprobante { get; set; }

        [XmlAttribute("Exportacion")]
        public string Exportacion { get; set; }

        [XmlAttribute("MetodoPago")]
        public string MetodoPago { get; set; }

        [XmlAttribute("LugarExpedicion")]
        public string LugarExpedicion { get; set; }

        [XmlElement("Emisor")]
        public Emisor Emisor { get; set; }

        [XmlElement("Receptor")]
        public Receptor Receptor { get; set; }

        [XmlElement("Conceptos")]
        public Conceptos Conceptos { get; set; }

        [XmlElement("Complemento")]
        public Complemento Complemento { get; set; }
    }

    public class Emisor
    {
        [XmlAttribute("Rfc")]
        public string Rfc { get; set; }

        [XmlAttribute("Nombre")]
        public string Nombre { get; set; }

        [XmlAttribute("RegimenFiscal")]
        public string RegimenFiscal { get; set; }
    }

    public class Receptor
    {
        [XmlAttribute("Rfc")]
        public string Rfc { get; set; }

        [XmlAttribute("Nombre")]
        public string Nombre { get; set; }

        [XmlAttribute("DomicilioFiscalReceptor")]
        public string DomicilioFiscalReceptor { get; set; }

        [XmlAttribute("RegimenFiscalReceptor")]
        public string RegimenFiscalReceptor { get; set; }

        [XmlAttribute("UsoCFDI")]
        public string UsoCFDI { get; set; }
    }

    public class Conceptos
    {
        [XmlElement("Concepto")]
        public Concepto Concepto { get; set; }
    }

    public class Concepto
    {
        [XmlAttribute("ClaveProdServ")]
        public string ClaveProdServ { get; set; }

        [XmlAttribute("Cantidad")]
        public decimal Cantidad { get; set; }

        [XmlAttribute("ClaveUnidad")]
        public string ClaveUnidad { get; set; }

        [XmlAttribute("Descripcion")]
        public string Descripcion { get; set; }

        [XmlAttribute("ValorUnitario")]
        public decimal ValorUnitario { get; set; }

        [XmlAttribute("Importe")]
        public decimal Importe { get; set; }

        [XmlAttribute("Descuento")]
        public decimal Descuento { get; set; }

        [XmlAttribute("ObjetoImp")]
        public string ObjetoImp { get; set; }
    }

    public class Complemento
    {
        [XmlElement(Namespace = "http://www.sat.gob.mx/nomina12")]
        public Nomina Nomina { get; set; }
    }

    [XmlRoot("Nomina", Namespace = "http://www.sat.gob.mx/nomina12")]
    public class Nomina
    {
        [XmlAttribute("Version")]
        public string Version { get; set; }

        // Add other properties representing the Nomina element
    }



}
