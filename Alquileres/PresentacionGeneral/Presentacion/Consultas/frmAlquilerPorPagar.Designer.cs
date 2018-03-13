namespace Presentacion.Consultas
{
    partial class frmAlquilerPorPagar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.dgAlquiler = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlquiler)).BeginInit();
            this.SuspendLayout();
            // 
            // GrupBox
            // 
            this.GrupBox.Controls.Add(this.dgAlquiler);
            this.GrupBox.Location = new System.Drawing.Point(12, 44);
            this.GrupBox.Size = new System.Drawing.Size(868, 290);
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(57, 17);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(823, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(12, 20);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Cliente";
            // 
            // dgAlquiler
            // 
            this.dgAlquiler.AllowUserToAddRows = false;
            this.dgAlquiler.AllowUserToDeleteRows = false;
            this.dgAlquiler.AllowUserToResizeRows = false;
            this.dgAlquiler.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgAlquiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAlquiler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colDesde,
            this.colHasta,
            this.colHora,
            this.colDia,
            this.colSemana,
            this.colPrecio});
            this.dgAlquiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAlquiler.Location = new System.Drawing.Point(3, 16);
            this.dgAlquiler.Name = "dgAlquiler";
            this.dgAlquiler.ReadOnly = true;
            this.dgAlquiler.RowHeadersVisible = false;
            this.dgAlquiler.Size = new System.Drawing.Size(862, 271);
            this.dgAlquiler.TabIndex = 1;
            // 
            // colProducto
            // 
            this.colProducto.DataPropertyName = "IDProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            this.colProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colProducto.Width = 150;
            // 
            // colDesde
            // 
            this.colDesde.DataPropertyName = "FechaDesde";
            this.colDesde.HeaderText = "Desde";
            this.colDesde.Name = "colDesde";
            this.colDesde.ReadOnly = true;
            this.colDesde.Width = 140;
            // 
            // colHasta
            // 
            this.colHasta.DataPropertyName = "FechaHasta";
            this.colHasta.HeaderText = "Hasta";
            this.colHasta.Name = "colHasta";
            this.colHasta.ReadOnly = true;
            this.colHasta.Width = 140;
            // 
            // colHora
            // 
            this.colHora.DataPropertyName = "TiempoHora";
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            // 
            // colDia
            // 
            this.colDia.DataPropertyName = "TiempoDia";
            this.colDia.HeaderText = "Dia";
            this.colDia.Name = "colDia";
            this.colDia.ReadOnly = true;
            // 
            // colSemana
            // 
            this.colSemana.DataPropertyName = "TiempoSemana";
            this.colSemana.HeaderText = "Semana";
            this.colSemana.Name = "colSemana";
            this.colSemana.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "PrecioEstimado";
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // frmAlquilerPorPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 346);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.Label2);
            this.Name = "frmAlquilerPorPagar";
            this.Text = "frmAlquilerPorPagar";
            this.Load += new System.EventHandler(this.frmAlquilerPorPagar_Load);
            this.Controls.SetChildIndex(this.GrupBox, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.cmbCliente, 0);
            this.GrupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAlquiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbCliente;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DataGridView dgAlquiler;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
    }
}