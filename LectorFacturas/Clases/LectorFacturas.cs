
using LectorFacturas.Modelos.Factura;
using LectorFacturas.Modelos.Translado4;
using LectorXML.Modelos.Translado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LectorFacturas.Clases
{
    class CFDILector
    {
        private string _version;
        private bool _esTranslado ;

        public bool  EsTranslado(){
            return _esTranslado;
        }
       private void ComprobarArchivo(string url)
        {
            XDocument xmlDoc = XDocument.Load(url);
            _version = xmlDoc.Root.Attribute("Version").Value;
            XElement trasladoElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "Traslado");
            _esTranslado=(trasladoElement!=null)?true:false;
        }

       public dynamic LeerFactura(string url)
        {
            this.ComprobarArchivo(url);
            if (!_esTranslado && _version.Contains("3.3"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LectorFacturas.Modelos.Factura.Comprobante));
                using (FileStream fs = new FileStream(url, FileMode.Open))
                {
                    LectorFacturas.Modelos.Factura.Comprobante comprobante = (LectorFacturas.Modelos.Factura.Comprobante)serializer.Deserialize(fs);
                    return comprobante;
                }
            }
            else if( _esTranslado && _version.Contains("3.3"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ComprobanteTranslado));
                using (FileStream fs = new FileStream(url, FileMode.Open))
                {
                    ComprobanteTranslado comprobante = (ComprobanteTranslado)serializer.Deserialize(fs);
                    return comprobante;
                }
            }
            else if (_esTranslado && _version.Contains("4.0"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ComprobanteTranslado4));
                using (FileStream fs = new FileStream(url, FileMode.Open))
                {
                    ComprobanteTranslado4 comprobante = (ComprobanteTranslado4)serializer.Deserialize(fs);
                    return comprobante;
                }
            }
            return null;
        }
    }
}
