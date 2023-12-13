using LectorFacturas.Clases;
using LectorFacturas.Modelos.Factura;
using LectorFacturas.Modelos.Translado4;
using LectorXML.Modelos.Translado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LectorFacturas
{
    public partial class Form1 : Form
    {
        private List<Comprobante> _factura = new List<Comprobante>();
        private List<ComprobanteTranslado> _translados = new List<ComprobanteTranslado>();
        private List<ComprobanteTranslado4> _translados4 = new List<ComprobanteTranslado4>();

        decimal _totalEmitidas = 0;
        decimal _totalRecibidas = 0;

        public Form1()
        {
            InitializeComponent();
            // CreateColumnsForDto(typeof(Comprobante), tabla);
            // CreateColumnsForDto(typeof(ComprobanteTranslado), tabla);
            GenerateColumnsForModel(typeof(ComprobanteTranslado4), tabla);
        }



        private void GenerateColumnsForModel(Type modelType, DataGridView dataGridView)
        {
            dataGridView.Columns.Clear(); // Limpiar las columnas existentes

            foreach (var property in modelType.GetProperties())
            {
                // Obtener el nombre y el tipo de la propiedad
                string propertyName = property.Name;
                Type propertyType = property.PropertyType;

                // Verificar si la propiedad es de tipo primitivo
                if (propertyType.IsPrimitive || propertyType == typeof(string) || propertyType == typeof(DateTime))
                {
                    // Crear una columna con el nombre y tipo de la propiedad
                    dataGridView.Columns.Add(propertyName, propertyName);

                    // Configurar otras propiedades de la columna según tus necesidades
                    // Por ejemplo, puedes establecer el ancho de la columna:
                    dataGridView.Columns[propertyName].Width = 100;

                    // Leer los atributos personalizados de la propiedad
                    object[] attributes = property.GetCustomAttributes(true);

                    foreach (var attribute in attributes)
                    {
                        // Puedes realizar acciones con cada atributo de la propiedad
                        // Por ejemplo, puedes establecer propiedades de la columna según los atributos
                        if (attribute is DisplayNameAttribute displayNameAttribute)
                        {
                            // Si el atributo es DisplayNameAttribute, establecer el encabezado de la columna
                            dataGridView.Columns[propertyName].HeaderText = displayNameAttribute.DisplayName;
                        }
                        // Puedes agregar más lógica según los atributos que tengas
                    }
                }
            }
        }


        // Función auxiliar para verificar si el tipo es una lista
        private bool IsList(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        private void AddRowsForDto(object dto, DataGridView dataGridView)
        {
            AddRowsForDtoRecursive(dto, dataGridView, "");
        }

        private void AddRowsForDtoRecursive(object dto, DataGridView dataGridView, string parentPrefix)
        {
            // Agregar una nueva fila al DataGridView
            int rowIndex = dataGridView.Rows.Add();

            // Obtener la fila recién agregada
            DataGridViewRow row = dataGridView.Rows[rowIndex];

            // Rellenar las celdas con los datos de las propiedades
            foreach (PropertyInfo propertyInfo in dto.GetType().GetProperties())
            {
                // Obtener el nombre y el tipo de la propiedad
                string propertyName = propertyInfo.Name;
                Type propertyType = propertyInfo.PropertyType;

                // Construir el nombre completo de la propiedad (considerando clases anidadas)
                string fullPropertyName = string.IsNullOrEmpty(parentPrefix)
                    ? propertyName
                    : $"{parentPrefix}.{propertyName}";

                // Verificar si la propiedad es una clase
                if (propertyType.IsClass && propertyType != typeof(string))
                {
                    // Si es una clase, omitirla y no realizar la llamada recursiva
                    continue;
                }

                // Obtener el valor de la propiedad mediante reflexión
                object propertyValue = propertyInfo.GetValue(dto);

                // Buscar la columna correspondiente y asignar el valor a la celda
                DataGridViewColumn column = dataGridView.Columns[fullPropertyName];
                if (column != null)
                {
                    row.Cells[column.Index].Value = propertyValue;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            LeerArchivos();

        }

        public void LeerArchivos()
        {
            _totalEmitidas = 0;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openDialog.FileNames)
                    CargarDatos(file);
            }
        }
        public void CargarDatos(string file)
        {
            CFDILector lector = new CFDILector();


            var objeto = lector.LeerFactura(file);

            if (!lector.EsTranslado())
            {
                Comprobante factura = objeto;
                AddRowsForDto(factura, tabla);
                _factura.Add(factura);
            }
            else if (lector.EsTranslado() && lector.ObtenerVersion().Contains("3.3"))
            {
                var factura = objeto;
                AddRowsForDto(factura, tabla);
                _translados.Add(factura);

            }
            else if (lector.EsTranslado() && lector.ObtenerVersion().Contains("4.0"))
            {
                var factura = objeto;
                AddRowsForDto(factura, tabla);
                _translados4.Add(factura);

            }

            _totalEmitidas = _translados.Sum(x => x.Conceptos.Concepto.Sum(c => Convert.ToDecimal(c.Importe)));
            _totalEmitidas += _translados4.Sum(x => x.Conceptos.Concepto.Sum(c => Convert.ToDecimal(c.Importe)));
            _totalRecibidas = _factura.Sum(x => Convert.ToDecimal(x.Conceptos.Concepto.Importe));
            lbl_totalEmitidas.Text = $"Suma de Importes de Facturas Emitidas:{_totalEmitidas}";
            lbl_totalRecibidas.Text = $"Suma de Importes de Facturas Recibidas:{_totalRecibidas}";

        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            _factura.Clear();
            _translados.Clear();
            _translados4.Clear();
            tabla.Rows.Clear();
            lbl_totalEmitidas.Text = "Suma de Importes:";
            _totalEmitidas = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

