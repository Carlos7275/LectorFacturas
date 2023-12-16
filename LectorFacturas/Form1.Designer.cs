namespace LectorFacturas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.unboundSource1 = new DevExpress.Data.UnboundSource(this.components);
            this.unboundSource2 = new DevExpress.Data.UnboundSource(this.components);
            this.tabla = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_examinar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_limpiar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "xml";
            this.openDialog.FileName = "openFileDialog1";
            this.openDialog.Filter = "|*.xml";
            this.openDialog.Multiselect = true;
            // 
            // tabla
            // 
            this.tabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabla.Location = new System.Drawing.Point(12, 100);
            this.tabla.MainView = this.gridView1;
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(660, 242);
            this.tabla.TabIndex = 9;
            this.tabla.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.tabla;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SubTotal", null, "")});
            this.gridView1.Name = "gridView1";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView3.GridControl = this.tabla;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowFooter = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.tabla;
            this.gridView2.Name = "gridView2";
            // 
            // btn_examinar
            // 
            this.btn_examinar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_examinar.ImageOptions.Image")));
            this.btn_examinar.Location = new System.Drawing.Point(22, 12);
            this.btn_examinar.Name = "btn_examinar";
            this.btn_examinar.Size = new System.Drawing.Size(101, 42);
            this.btn_examinar.TabIndex = 11;
            this.btn_examinar.Text = "Examinar";
            this.btn_examinar.Click += new System.EventHandler(this.btn_examinar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpiar.ImageOptions.Image")));
            this.btn_limpiar.Location = new System.Drawing.Point(149, 13);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(134, 41);
            this.btn_limpiar.TabIndex = 12;
            this.btn_limpiar.Text = "Limpiar Datos";
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 370);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_examinar);
            this.Controls.Add(this.tabla);
            this.Name = "Form1";
            this.SurfaceMaterial = DevExpress.XtraEditors.SurfaceMaterial.Acrylic;
            this.Text = "Lector de Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unboundSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openDialog;
        private DevExpress.Data.UnboundSource unboundSource1;
        private DevExpress.Data.UnboundSource unboundSource2;
        private DevExpress.XtraGrid.GridControl tabla;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_examinar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btn_limpiar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}

