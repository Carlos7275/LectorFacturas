using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace LectorFacturas.Modelos.Factura
{
    [XmlRoot(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Emisor
    {
        [XmlAttribute(AttributeName = "Rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute(AttributeName = "RegimenFiscal")]
        public string RegimenFiscal { get; set; }
    }

    [XmlRoot(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Receptor
    {
        [XmlAttribute(AttributeName = "Rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "Nombre")]
        public string Nombre { get; set; }
        [XmlAttribute(AttributeName = "UsoCFDI")]
        public string UsoCFDI { get; set; }
    }

    [XmlRoot(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Concepto
    {
        [XmlAttribute(AttributeName = "ClaveProdServ")]
        public string ClaveProdServ { get; set; }
        [XmlAttribute(AttributeName = "Cantidad")]
        public string Cantidad { get; set; }
        [XmlAttribute(AttributeName = "ClaveUnidad")]
        public string ClaveUnidad { get; set; }
        [XmlAttribute(AttributeName = "Descripcion")]
        public string Descripcion { get; set; }
        [XmlAttribute(AttributeName = "ValorUnitario")]
        public string ValorUnitario { get; set; }
        [XmlAttribute(AttributeName = "Importe")]
        public string Importe { get; set; }
    }

    [XmlRoot(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Conceptos
    {
        [XmlElement(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Concepto Concepto { get; set; }
    }

    [XmlRoot(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    public class TimbreFiscalDigital
    {
        [XmlAttribute(AttributeName = "tfd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tfd { get; set; }
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
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }

    [XmlRoot(ElementName = "DoctoRelacionado", Namespace = "http://www.sat.gob.mx/Pagos")]
    public class DoctoRelacionado
    {
        [XmlAttribute(AttributeName = "IdDocumento")]
        public string IdDocumento { get; set; }
        [XmlAttribute(AttributeName = "Serie")]
        public string Serie { get; set; }
        [XmlAttribute(AttributeName = "Folio")]
        public string Folio { get; set; }
        [XmlAttribute(AttributeName = "MonedaDR")]
        public string MonedaDR { get; set; }
        [XmlAttribute(AttributeName = "MetodoDePagoDR")]
        public string MetodoDePagoDR { get; set; }
        [XmlAttribute(AttributeName = "NumParcialidad")]
        public string NumParcialidad { get; set; }
        [XmlAttribute(AttributeName = "ImpSaldoAnt")]
        public string ImpSaldoAnt { get; set; }
        [XmlAttribute(AttributeName = "ImpPagado")]
        public string ImpPagado { get; set; }
        [XmlAttribute(AttributeName = "ImpSaldoInsoluto")]
        public string ImpSaldoInsoluto { get; set; }
    }

    [XmlRoot(ElementName = "Pago", Namespace = "http://www.sat.gob.mx/Pagos")]
    public class Pago
    {
        [XmlElement(ElementName = "DoctoRelacionado", Namespace = "http://www.sat.gob.mx/Pagos")]
        public DoctoRelacionado DoctoRelacionado { get; set; }
        [XmlAttribute(AttributeName = "FechaPago")]
        public string FechaPago { get; set; }
        [XmlAttribute(AttributeName = "FormaDePagoP")]
        public string FormaDePagoP { get; set; }
        [XmlAttribute(AttributeName = "MonedaP")]
        public string MonedaP { get; set; }
        [XmlAttribute(AttributeName = "Monto")]
        public string Monto { get; set; }
        [XmlAttribute(AttributeName = "NumOperacion")]
        public string NumOperacion { get; set; }
        [XmlAttribute(AttributeName = "RfcEmisorCtaOrd")]
        public string RfcEmisorCtaOrd { get; set; }
    }

    [XmlRoot(ElementName = "Pagos", Namespace = "http://www.sat.gob.mx/Pagos")]
    public class Pagos
    {
        [XmlElement(ElementName = "Pago", Namespace = "http://www.sat.gob.mx/Pagos")]
        public Pago Pago { get; set; }
        [XmlAttribute(AttributeName = "pago10", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Pago10 { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Complemento
    {
        [XmlElement(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
        public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
        [XmlElement(ElementName = "Pagos", Namespace = "http://www.sat.gob.mx/Pagos")]
        public Pagos Pagos { get; set; }
    }

    [XmlRoot(ElementName = "Comprobante", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Comprobante
    {
        [XmlElement(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Conceptos Conceptos { get; set; }
        [XmlElement(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Complemento Complemento { get; set; }
        [XmlAttribute(AttributeName = "cfdi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cfdi { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
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
        [XmlAttribute(AttributeName = "NoCertificado")]
        public string NoCertificado { get; set; }
        [XmlAttribute(AttributeName = "Certificado")]
        public string Certificado { get; set; }
        [XmlAttribute(AttributeName = "SubTotal")]
        public string SubTotal { get; set; }
        [XmlAttribute(AttributeName = "Moneda")]
        public string Moneda { get; set; }
        [XmlAttribute(AttributeName = "Total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "TipoDeComprobante")]
        public string TipoDeComprobante { get; set; }
        [XmlAttribute(AttributeName = "LugarExpedicion")]
        public string LugarExpedicion { get; set; }
    }

}