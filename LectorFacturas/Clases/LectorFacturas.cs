
using LectorFacturas.Modelos;
using LectorFacturas.Modelos.Translado4;
using LectorXML.Modelos.Translado;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LectorFacturas.Clases
{
    class CFDILector
    {
        private string _version;
        private bool _esTranslado;

        public bool EsTranslado()
        {
            return _esTranslado;
        }
        private bool ComprobarArchivo(string url)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(url);
                 _version = xmlDoc.Root.Attribute("Version").Value;

                XElement trasladoElement = xmlDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "Traslado");
                _esTranslado = (trasladoElement != null);
                return true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "¡Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public string ObtenerVersion()
        {
            return _version;
        }
        public dynamic LeerFactura(string url)
        {

            if (this.ComprobarArchivo(url))
            {
                if (_version.Contains("3.3"))
                {
                    if (!_esTranslado)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(LectorFacturas.Modelos.Factura.Comprobante));
                        using (FileStream fs = new FileStream(url, FileMode.Open))
                        {
                            LectorFacturas.Modelos.Factura.Comprobante comprobante = (LectorFacturas.Modelos.Factura.Comprobante)serializer.Deserialize(fs);
                            return comprobante;
                        }
                    }
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ComprobanteTranslado));
                        using (FileStream fs = new FileStream(url, FileMode.Open))
                        {
                            ComprobanteTranslado comprobante = (ComprobanteTranslado)serializer.Deserialize(fs);
                            return comprobante;
                        }
                    }

                }
                else if (_version.Contains("4.0"))
                {
                    if (!_esTranslado)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Comprobante4));
                        using (FileStream fs = new FileStream(url, FileMode.Open))
                        {
                            Comprobante4 comprobante = (Comprobante4)serializer.Deserialize(fs);
                            return comprobante;
                        }
                    }
                    else
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ComprobanteTranslado4));
                        using (FileStream fs = new FileStream(url, FileMode.Open))
                        {
                            ComprobanteTranslado4 comprobante = (ComprobanteTranslado4)serializer.Deserialize(fs);
                            return comprobante;
                        }
                    }
                }

            }
            return null;
        }
    }
}
