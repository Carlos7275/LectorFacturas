using LectorFacturas.Clases;
using LectorFacturas.Modelos.Factura;
using LectorXML.Modelos.Translado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectorFacturas
{
    public partial class Form1 : Form
    {
        private List<string> _archivos = new List<string>();
        private List<Comprobante> _factura = new List<Comprobante>();
        private List<dynamic> _translados = new List<dynamic>();

        public Form1()
        {
            InitializeComponent();
            tabla.Columns.Add("Version", "Version");
            tabla.Columns.Add("EmisorRfc", "RFC Emisor");
            tabla.Columns.Add("EmisorNombre", "Nombre Emisor");
            tabla.Columns.Add("ReceptorRfc", "RFC Receptor");
            tabla.Columns.Add("ReceptorNombre", "Nombre Receptor");
            tabla.Columns.Add("ConceptoDescripcion", "Descripción Concepto");
            tabla.Columns.Add("Cantidad", "Cantidad");
            tabla.Columns.Add("Valor Unitario", "Valor Unitario");
            tabla.Columns.Add("Subtotal", "Subtotal");

            tabla2.Columns.Add("Version", "Version");
            tabla2.Columns.Add("EmisorRfc", "RFC Emisor");
            tabla2.Columns.Add("EmisorNombre", "Nombre Emisor");
            tabla2.Columns.Add("ReceptorRfc", "RFC Receptor");
            tabla2.Columns.Add("ReceptorNombre", "Nombre Receptor");
            tabla2.Columns.Add("Impuestos", "Impuestos Trasladados");

            tabla.AutoGenerateColumns = false;
            tabla2.AutoGenerateColumns = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LeerArchivos();
            CargarDatos();
        }

        public void LeerArchivos()
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openDialog.FileNames)
                    _archivos.Add(file);
            }
        }
        public void CargarDatos()
        {
            CFDILector lector = new CFDILector();
            tabla.Rows.Clear();
            tabla2.Rows.Clear();

            foreach (string url in _archivos)
            {
                var objeto = lector.LeerFactura(url);

                if (!lector.EsTranslado())
                {
                    Comprobante factura = objeto;
                    tabla.Rows.Add(
                        factura.Version,
                        factura.Emisor.Rfc,
                        factura.Emisor.Nombre,
                        factura.Receptor.Rfc,
                        factura.Receptor.Nombre,
                        factura.Conceptos.Concepto.Descripcion,
                        factura.Conceptos.Concepto.Cantidad,
                        factura.Conceptos.Concepto.ValorUnitario,
                        factura.SubTotal 
                    );
                   
                    _factura.Add(factura);
                }
                else
                {
                    var factura = objeto;

                    tabla2.Rows.Add(
                        factura.Version,
                        factura.Emisor.Rfc,
                        factura.Emisor.Nombre,
                        factura.Receptor.Rfc,
                        factura.Receptor.Nombre,
                        ""
                      );

                    _translados.Add(factura);
                }
            }

        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            _archivos.Clear();
            _factura.Clear();
            tabla.Rows.Clear();
        }
    }
}
