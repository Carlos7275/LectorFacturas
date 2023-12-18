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
using System.Linq;
using System.Threading.Tasks;
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
            labelControl1.Text = $"Version: {Enviroment.Version}";
        }

        public bool ExisteFactura(string folio)
        {
            var existeEnFactura = _factura.Any(x => x.Folio == folio);

            var existeEnFactura4 = _factura4.Any(x => x.Folio == folio);

            var existeEnTranslados = _translados.Any(x => x.Folio == folio);

            var existeEnTranslados4 = _translados4.Any(x => x.Folio == folio);

            return existeEnFactura ||
                    existeEnFactura4 ||
                    existeEnTranslados ||
                    existeEnTranslados4;
        }
        public void InicializarGrid()
        {
            var datos = Utilidades.CombinarTablas(
                new List<string> {
                    "Version",
                    "Emisor.Rfc",
                    //"Emisor.Nombre",
                    "Receptor.Rfc",
                    //"Receptor.Nombre",
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

            if (gridView1.Columns.Count > 0)
            {
                gridView1.Columns[0].Summary.Clear();
                gridView1.Columns[6].Summary.Clear();
                gridView1.Columns[7].Summary.Clear();
                gridView1.Columns[8].Summary.Clear();

                GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubTotal", "${0}");
                GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Descuento", "${0}");
                GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "${0}");
                GridColumnSummaryItem item4 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Conteo", "#{0}");

                gridView1.Columns[6].Summary.Add(item1);
                gridView1.Columns[7].Summary.Add(item2);
                gridView1.Columns[8].Summary.Add(item3);
                gridView1.Columns[0].Summary.Add(item4);
            }
        }

        public void InicializarDetalles()
        {
            List<FacturaDetalle> lista = new List<FacturaDetalle>();

            foreach (var item in _factura)
            {
                lista.Add(new FacturaDetalle
                {
                    Descripcion = item.Conceptos.Concepto.Descripcion,
                    Folio = item.Folio,
                    RFCEmisor = item.Emisor.Rfc,
                    RFCReceptor = item.Receptor.Rfc,
                    Version = item.Version,
                    Cantidad = item.Conceptos.Concepto.Cantidad,
                    Importe = item.Conceptos.Concepto.Importe,
                    ValorUnitario = item.Conceptos.Concepto.ValorUnitario,
                    Fecha = DateTime.Parse(item.Fecha).ToString("dd/MM/yyyy hh:mm:ss")
                });

            }

            foreach (var item in _factura4)
            {
                lista.Add(new FacturaDetalle
                {
                    Descripcion = item.Conceptos.Concepto.Descripcion,
                    Folio = item.Folio,
                    RFCEmisor = item.Emisor.Rfc,
                    RFCReceptor = item.Receptor.Rfc,
                    Version = item.Version,
                    Cantidad = item.Conceptos.Concepto.Cantidad.ToString(),
                    Importe = item.Conceptos.Concepto.Importe.ToString(),
                    ValorUnitario = item.Conceptos.Concepto.ValorUnitario.ToString(),
                    Fecha = item.Fecha.ToString("dd/MM/yyyy hh:mm:ss")
                });

            }
            foreach (var item in _translados)
            {
                foreach (var concepto in item.Conceptos.Concepto)
                    lista.Add(new FacturaDetalle
                    {
                        Descripcion = concepto.Descripcion,
                        Folio = item.Folio,
                        RFCEmisor = item.Emisor.Rfc,
                        RFCReceptor = item.Receptor.Rfc,
                        Version = item.Version,
                        Cantidad = concepto.Cantidad,
                        ValorUnitario = concepto.ValorUnitario,
                        Importe = concepto.Importe,
                        Base = concepto.Impuestos?.Traslados?.Traslado?.Base,
                        ImporteIva = concepto.Impuestos?.Traslados?.Traslado?.Importe,
                        TasaOCuota = concepto.Impuestos?.Traslados?.Traslado?.TasaOCuota,
                        Fecha = DateTime.Parse(item.Fecha).ToString("dd/MM/yyyy hh:mm:ss")

                    });
            }

            foreach (var item in _translados4)
            {
                foreach (var concepto in item.Conceptos.Concepto)
                    lista.Add(new FacturaDetalle
                    {
                        Descripcion = concepto.Descripcion,
                        Folio = item.Folio,
                        RFCEmisor = item.Emisor.Rfc,
                        RFCReceptor = item.Receptor.Rfc,
                        Version = item.Version,
                        Cantidad = concepto.Cantidad,
                        ValorUnitario = concepto.ValorUnitario,
                        Importe = concepto.Importe,
                        Base = concepto.Impuestos?.Traslados?.Traslado?.Base,
                        ImporteIva = concepto.Impuestos?.Traslados?.Traslado?.Importe,
                        TasaOCuota = concepto.Impuestos?.Traslados?.Traslado?.TasaOCuota,
                        Fecha = DateTime.Parse(item.Fecha).ToString("dd/MM/yyyy hh:mm:ss")
                    });
            }

            var datos2 = Utilidades.CombinarTablas(
                new List<string> {
                    "Version",
                    "Folio",
                    "Fecha",
                    "RFCEmisor",
                    "RFCReceptor",
                    "Descripcion",
                    "Cantidad",
                    "ValorUnitario",
                    "Importe",
                    "Base",
                    "ImporteIva",
                    "TasaOCuota"
                },
                    lista
                );

            GridView gridView = gridView4;
            gridView.OptionsView.ShowGroupPanel = true;
            gridView.OptionsView.ShowFooter = true;


            gridView.BestFitColumns();
            gridView4.OptionsBehavior.Editable = false;

            tabla2.DataSource = datos2;
            if (gridView4.Columns.Count > 0)
            {
                gridView4.Columns[0].Summary.Clear();
                gridView4.Columns[7].Summary.Clear();
                gridView4.Columns[8].Summary.Clear();
                gridView4.Columns[10].Summary.Clear();

                GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "${0}");
                GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Base", "${0}");
                GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ImporteIva", "${0}");
                GridColumnSummaryItem item4 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Conteo", "#{0}");

                gridView4.Columns[7].Summary.Add(item1);
                gridView4.Columns[8].Summary.Add(item2);
                gridView4.Columns[10].Summary.Add(item3);
                gridView4.Columns[0].Summary.Add(item4);
            }
        }
        public void LeerArchivos()
        {

            if (openDialog.ShowDialog() == DialogResult.OK)
                foreach (string file in openDialog.FileNames)
                    CargarDatos(file);

            InicializarGrid();
            InicializarDetalles();

        }
        public void CargarDatos(string file)
        {
            CFDILector lector = new CFDILector();
            var objeto = lector.LeerFactura(file);

            if (objeto != null)
            {
                if (!ExisteFactura(objeto.Folio))
                {
                    if (lector.ObtenerVersion().Contains("3.3"))
                    {
                        if (!lector.EsTranslado())
                            _factura.Add((Comprobante)objeto);

                        else
                            _translados.Add((ComprobanteTranslado)objeto);
                    }

                    if (lector.ObtenerVersion().Contains("4.0"))
                    {
                        if (!lector.EsTranslado())
                            _factura4.Add((Comprobante4)objeto);

                        else if (lector.EsTranslado())
                            _translados4.Add((ComprobanteTranslado4)objeto);
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
            tabla2.DataSource = null;
        }

    }
}

