
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using LectorFacturas.Modelos.Factura;
namespace LectorXML.Modelos.Translado
{
   
    [XmlRoot(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Traslado
    {
        [XmlAttribute(AttributeName = "Base")]
        public string Base { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public string Importe { get; set; }
        [XmlAttribute(AttributeName = "Impuesto")]
        public string Impuesto { get; set; }
        [XmlAttribute(AttributeName = "TasaOCuota")]
        public string TasaOCuota { get; set; }
        [XmlAttribute(AttributeName = "TipoFactor")]
        public string TipoFactor { get; set; }
    }

    [XmlRoot(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Traslados
    {
        [XmlElement(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Traslado Traslado { get; set; }
    }

    [XmlRoot(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Impuestos
    {
        [XmlElement(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Traslados Traslados { get; set; }
        [XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
        public string TotalImpuestosTrasladados { get; set; }
    }

    [XmlRoot(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Concepto
    {
        [XmlElement(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Impuestos Impuestos { get; set; }
        [XmlAttribute(AttributeName = "Cantidad")]
        public string Cantidad { get; set; }
        [XmlAttribute(AttributeName = "ClaveProdServ")]
        public string ClaveProdServ { get; set; }
        [XmlAttribute(AttributeName = "ClaveUnidad")]
        public string ClaveUnidad { get; set; }
        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public string Importe { get; set; }
        [XmlAttribute(AttributeName = "NoIdentificacion")]
        public string NoIdentificacion { get; set; }
        [XmlAttribute(AttributeName = "Unidad")]
        public string Unidad { get; set; }
        [XmlAttribute(AttributeName = "ValorUnitario")]
        public string ValorUnitario { get; set; }
    }

    [XmlRoot(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Conceptos
    {
        [XmlElement(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public List<Concepto> Concepto { get; set; }
    }

    [XmlRoot(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    public class TimbreFiscalDigital
    {
        [XmlAttribute(AttributeName = "tfd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tfd { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "UUID")]
        public string UUID { get; set; }
        [XmlAttribute(AttributeName = "SelloCFD")]
        public string SelloCFD { get; set; }
        [XmlAttribute(AttributeName = "NoCertificadoSAT")]
        public string NoCertificadoSAT { get; set; }
        [XmlAttribute(AttributeName = "FechaTimbrado")]
        public string FechaTimbrado { get; set; }
        [XmlAttribute(AttributeName = "SelloSAT")]
        public string SelloSAT { get; set; }
        [XmlAttribute(AttributeName = "RfcProvCertif")]
        public string RfcProvCertif { get; set; }
    }

    [XmlRoot(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Complemento
    {
        [XmlElement(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
    }

    [XmlRoot(ElementName = "Comprobante", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class ComprobanteTranslado
    {
        [XmlElement(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Conceptos Conceptos { get; set; }
        [XmlElement(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Impuestos Impuestos { get; set; }
        [XmlElement(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Complemento Complemento { get; set; }
        [XmlAttribute(AttributeName = "cfdi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cfdi { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "Certificado")]
        public string Certificado { get; set; }
        [XmlAttribute(AttributeName = "Fecha")]
        public string Fecha { get; set; }
        [XmlAttribute(AttributeName = "Folio")]
        public string Folio { get; set; }
        [XmlAttribute(AttributeName = "FormaPago")]
        public string FormaPago { get; set; }
        [XmlAttribute(AttributeName = "LugarExpedicion")]
        public string LugarExpedicion { get; set; }
        [XmlAttribute(AttributeName = "MetodoPago")]
        public string MetodoPago { get; set; }
        [XmlAttribute(AttributeName = "Moneda")]
        public string Moneda { get; set; }
        [XmlAttribute(AttributeName = "NoCertificado")]
        public string NoCertificado { get; set; }
        [XmlAttribute(AttributeName = "Sello")]
        public string Sello { get; set; }
        [XmlAttribute(AttributeName = "SubTotal")]
        public string SubTotal { get; set; }
        [XmlAttribute(AttributeName = "TipoDeComprobante")]
        public string TipoDeComprobante { get; set; }
        [XmlAttribute(AttributeName = "Total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }

}

