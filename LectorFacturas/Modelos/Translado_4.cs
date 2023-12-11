using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LectorFacturas.Modelos.Translado4
{
        [XmlRoot(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Emisor
        {
            [XmlAttribute(AttributeName = "Rfc")]
            public string Rfc { get; set; }
            [XmlAttribute(AttributeName = "Nombre")]
            public string Nombre { get; set; }
            [XmlAttribute(AttributeName = "RegimenFiscal")]
            public string RegimenFiscal { get; set; }
        }

        [XmlRoot(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Receptor
        {
            [XmlAttribute(AttributeName = "Rfc")]
            public string Rfc { get; set; }
            [XmlAttribute(AttributeName = "Nombre")]
            public string Nombre { get; set; }
            [XmlAttribute(AttributeName = "DomicilioFiscalReceptor")]
            public string DomicilioFiscalReceptor { get; set; }
            [XmlAttribute(AttributeName = "RegimenFiscalReceptor")]
            public string RegimenFiscalReceptor { get; set; }
            [XmlAttribute(AttributeName = "UsoCFDI")]
            public string UsoCFDI { get; set; }
        }

        [XmlRoot(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Traslado
        {
            [XmlAttribute(AttributeName = "Base")]
            public string Base { get; set; }
            [XmlAttribute(AttributeName = "Impuesto")]
            public string Impuesto { get; set; }
            [XmlAttribute(AttributeName = "TipoFactor")]
            public string TipoFactor { get; set; }
            [XmlAttribute(AttributeName = "TasaOCuota")]
            public string TasaOCuota { get; set; }
            [XmlAttribute(AttributeName = "Importe")]
            public string Importe { get; set; }
        }

        [XmlRoot(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Traslados
        {
            [XmlElement(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Traslado Traslado { get; set; }
        }

        [XmlRoot(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Impuestos
        {
            [XmlElement(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Traslados Traslados { get; set; }
            [XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
            public string TotalImpuestosTrasladados { get; set; }
        }

        [XmlRoot(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Concepto
        {
            [XmlElement(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Impuestos Impuestos { get; set; }
            [XmlAttribute(AttributeName = "ClaveProdServ")]
            public string ClaveProdServ { get; set; }
            [XmlAttribute(AttributeName = "Cantidad")]
            public string Cantidad { get; set; }
            [XmlAttribute(AttributeName = "ClaveUnidad")]
            public string ClaveUnidad { get; set; }
            [XmlAttribute(AttributeName = "Unidad")]
            public string Unidad { get; set; }
            [XmlAttribute(AttributeName = "Descripcion")]
            public string Descripcion { get; set; }
            [XmlAttribute(AttributeName = "ValorUnitario")]
            public string ValorUnitario { get; set; }
            [XmlAttribute(AttributeName = "Importe")]
            public string Importe { get; set; }
            [XmlAttribute(AttributeName = "Descuento")]
            public string Descuento { get; set; }
            [XmlAttribute(AttributeName = "ObjetoImp")]
            public string ObjetoImp { get; set; }
        }

        [XmlRoot(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Conceptos
        {
            [XmlElement(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public List<Concepto> Concepto { get; set; }
        }

        [XmlRoot(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public class TimbreFiscalDigital
        {
            [XmlAttribute(AttributeName = "tfd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Tfd { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string SchemaLocation { get; set; }
            [XmlAttribute(AttributeName = "Version")]
            public string Version { get; set; }
            [XmlAttribute(AttributeName = "UUID")]
            public string UUID { get; set; }
            [XmlAttribute(AttributeName = "FechaTimbrado")]
            public string FechaTimbrado { get; set; }
            [XmlAttribute(AttributeName = "RfcProvCertif")]
            public string RfcProvCertif { get; set; }
            [XmlAttribute(AttributeName = "SelloCFD")]
            public string SelloCFD { get; set; }
            [XmlAttribute(AttributeName = "NoCertificadoSAT")]
            public string NoCertificadoSAT { get; set; }
            [XmlAttribute(AttributeName = "SelloSAT")]
            public string SelloSAT { get; set; }
        }

        [XmlRoot(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class Complemento
        {
            [XmlElement(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
            public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
        }

        [XmlRoot(ElementName = "Comprobante", Namespace = "http://www.sat.gob.mx/cfd/4")]
        public class ComprobanteTranslado4
        {
            [XmlElement(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Emisor Emisor { get; set; }
            [XmlElement(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Receptor Receptor { get; set; }
            [XmlElement(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Conceptos Conceptos { get; set; }
            [XmlElement(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Impuestos Impuestos { get; set; }
            [XmlElement(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/4")]
            public Complemento Complemento { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsd { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "cfdi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Cfdi { get; set; }
            [XmlAttribute(AttributeName = "Version")]
            public string Version { get; set; }
            [XmlAttribute(AttributeName = "Serie")]
            public string Serie { get; set; }
            [XmlAttribute(AttributeName = "Folio")]
            public string Folio { get; set; }
            [XmlAttribute(AttributeName = "Fecha")]
            public string Fecha { get; set; }
            [XmlAttribute(AttributeName = "Sello")]
            public string Sello { get; set; }
            [XmlAttribute(AttributeName = "FormaPago")]
            public string FormaPago { get; set; }
            [XmlAttribute(AttributeName = "SubTotal")]
            public string SubTotal { get; set; }
            [XmlAttribute(AttributeName = "Descuento")]
            public string Descuento { get; set; }
            [XmlAttribute(AttributeName = "Moneda")]
            public string Moneda { get; set; }
            [XmlAttribute(AttributeName = "TipoCambio")]
            public string TipoCambio { get; set; }
            [XmlAttribute(AttributeName = "Total")]
            public string Total { get; set; }
            [XmlAttribute(AttributeName = "TipoDeComprobante")]
            public string TipoDeComprobante { get; set; }
            [XmlAttribute(AttributeName = "Exportacion")]
            public string Exportacion { get; set; }
            [XmlAttribute(AttributeName = "MetodoPago")]
            public string MetodoPago { get; set; }
            [XmlAttribute(AttributeName = "LugarExpedicion")]
            public string LugarExpedicion { get; set; }
            [XmlAttribute(AttributeName = "Certificado")]
            public string Certificado { get; set; }
            [XmlAttribute(AttributeName = "NoCertificado")]
            public string NoCertificado { get; set; }
            [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string SchemaLocation { get; set; }
        }

    }