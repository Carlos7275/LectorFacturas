using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using LectorFacturas.Clases;
using LectorFacturas.Modelos;
using LectorFacturas.Modelos.Factura;
using LectorFacturas.Modelos.Translado4;
using LectorXML.Modelos.Translado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LectorFacturas
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private List<Comprobante> _factura = new List<Comprobante>();
        private List<Comprobante4> _factura4 = new List<Comprobante4>();

       private List<ComprobanteTranslado> _translados = new List<ComprobanteTranslado>();
       private List<ComprobanteTranslado4> _translados4 = new List<ComprobanteTranslado4>();

        public Form1()
        {
            InitializeComponent();
        }

        public void InitializeGrid()
        {
            var datos = Utilidades.CombinarTablas(
                new List<string> {
                    "Version",
                    "Emisor.Rfc",
                    "Emisor.Nombre",
                    "Receptor.Rfc",
                    "Receptor.Nombre",
                    "MetodoPago",
                    "Fecha",
                    "Folio",
                    "SubTotal",
                    "Descuento",
                    "Total",
                    "FormaPago"
                },
                 _factura,
                 _factura4,
                _translados,
                _translados4
                );


            tabla.DataSource = datos;

            GridView gridView = gridView1;
            gridView.OptionsView.ShowGroupPanel = true;
            gridView.OptionsView.ShowFooter = true;


            gridView.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;

            if (datos.Rows.Count >0)
            {
                gridView1.Columns[0].Summary.Clear();
                gridView1.Columns[8].Summary.Clear();
                gridView1.Columns[9].Summary.Clear();
                gridView1.Columns[10].Summary.Clear();

                GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubTotal", "${0}");
                GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Descuento", "${0}");
                GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "${0}");
                GridColumnSummaryItem item4 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Conteo", "#{0}");

                gridView1.Columns[8].Summary.Add(item1);
                gridView1.Columns[9].Summary.Add(item2);
                gridView1.Columns[10].Summary.Add(item3);
                gridView1.Columns[0].Summary.Add(item4);
            }
        }


        public void LeerArchivos()
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openDialog.FileNames)
                    CargarDatos(file);
            }
            InitializeGrid();

        }
        public void CargarDatos(string file)
        {
            CFDILector lector = new CFDILector();
            var objeto = lector.LeerFactura(file);
            if (objeto != null)
            {
                if (lector.ObtenerVersion().Contains("3.3"))
                {
                    if (!lector.EsTranslado())
                    {
                        Comprobante factura = objeto;
                        _factura.Add(factura);
                    }
                    else
                    {
                        ComprobanteTranslado factura = objeto;
                        _translados.Add(factura);
                    }
                }

                if (lector.ObtenerVersion().Contains("4.0"))
                {
                    if (!lector.EsTranslado())
                    {
                        Comprobante4 factura = objeto;
                        _factura4.Add(factura);
                    }

                    else if (lector.EsTranslado())
                    {
                        ComprobanteTranslado4 factura = objeto;
                        _translados4.Add(factura);
                    }
                }
            }

        }

        private void btn_examinar_Click(object sender, EventArgs e)
        {
            LeerArchivos();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            _factura.Clear();
            _factura4.Clear();
            _translados.Clear();
            _translados4.Clear();
            tabla.DataSource = null;
        }
    }
}

