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
            this.tabla2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(12, 75);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(648, 166);
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
            this.Btn_Examinar.Location = new System.Drawing.Point(32, 23);
            this.Btn_Examinar.Name = "Btn_Examinar";
            this.Btn_Examinar.Size = new System.Drawing.Size(88, 29);
            this.Btn_Examinar.TabIndex = 1;
            this.Btn_Examinar.Text = "Examinar";
            this.Btn_Examinar.UseVisualStyleBackColor = true;
            this.Btn_Examinar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(169, 28);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Limpiar.TabIndex = 2;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // tabla2
            // 
            this.tabla2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tabla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla2.Location = new System.Drawing.Point(12, 247);
            this.tabla2.Name = "tabla2";
            this.tabla2.Size = new System.Drawing.Size(648, 166);
            this.tabla2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 495);
            this.Controls.Add(this.tabla2);
            this.Controls.Add(this.Btn_Limpiar);
            this.Controls.Add(this.Btn_Examinar);
            this.Controls.Add(this.tabla);
            this.Name = "Form1";
            this.Text = "Lector de Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Button Btn_Examinar;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.DataGridView tabla2;
    }
}

