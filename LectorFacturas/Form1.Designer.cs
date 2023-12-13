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
            this.tabla = new System.Windows.Forms.DataGridView();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.Btn_Examinar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.lbl_totalEmitidas = new System.Windows.Forms.Label();
            this.lbl_totalRecibidas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabla.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(13, 122);
            this.tabla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 62;
            this.tabla.Size = new System.Drawing.Size(972, 255);
            this.tabla.TabIndex = 0;
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "xml";
            this.openDialog.FileName = "openFileDialog1";
            this.openDialog.Filter = "|*.xml";
            this.openDialog.Multiselect = true;
            // 
            // Btn_Examinar
            // 
            this.Btn_Examinar.Location = new System.Drawing.Point(48, 35);
            this.Btn_Examinar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Examinar.Name = "Btn_Examinar";
            this.Btn_Examinar.Size = new System.Drawing.Size(132, 45);
            this.Btn_Examinar.TabIndex = 1;
            this.Btn_Examinar.Text = "Examinar";
            this.Btn_Examinar.UseVisualStyleBackColor = true;
            this.Btn_Examinar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(254, 43);
            this.Btn_Limpiar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(112, 35);
            this.Btn_Limpiar.TabIndex = 2;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // lbl_totalEmitidas
            // 
            this.lbl_totalEmitidas.AutoSize = true;
            this.lbl_totalEmitidas.Location = new System.Drawing.Point(451, 82);
            this.lbl_totalEmitidas.Name = "lbl_totalEmitidas";
            this.lbl_totalEmitidas.Size = new System.Drawing.Size(298, 20);
            this.lbl_totalEmitidas.TabIndex = 3;
            this.lbl_totalEmitidas.Text = "Suma de Importes de Facturas Emitidas:";
            // 
            // lbl_totalRecibidas
            // 
            this.lbl_totalRecibidas.AutoSize = true;
            this.lbl_totalRecibidas.Location = new System.Drawing.Point(451, 43);
            this.lbl_totalRecibidas.Name = "lbl_totalRecibidas";
            this.lbl_totalRecibidas.Size = new System.Drawing.Size(307, 20);
            this.lbl_totalRecibidas.TabIndex = 4;
            this.lbl_totalRecibidas.Text = "Suma de Importes de Facturas Recibidas:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 391);
            this.Controls.Add(this.lbl_totalRecibidas);
            this.Controls.Add(this.lbl_totalEmitidas);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Examinar);
            this.Controls.Add(this.tabla);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Lector de Facturas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Button Btn_Examinar;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Label lbl_totalEmitidas;
        private System.Windows.Forms.Label lbl_totalRecibidas;
    }
}

