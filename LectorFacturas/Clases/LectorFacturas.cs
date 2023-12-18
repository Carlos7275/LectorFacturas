
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
            if (!ComprobarArchivo(url)) return null;

            Type comprobanteType = null;

            if (_version.Contains("3.3"))
            {
                comprobanteType = _esTranslado ? typeof(ComprobanteTranslado) : typeof(LectorFacturas.Modelos.Factura.Comprobante);
            }
            else if (_version.Contains("4.0"))
            {
                comprobanteType = _esTranslado ? typeof(ComprobanteTranslado4) : typeof(Comprobante4);
            }

            if (comprobanteType == null) return null;

            XmlSerializer serializer = new XmlSerializer(comprobanteType);

            using (FileStream fs = new FileStream(url, FileMode.Open))
            {
                return serializer.Deserialize(fs);
            }
        }

    }
}
