namespace Presentacion.Operaciones
{
    partial class frmAlquiler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlquiler));
            this.mstpMenuMaestro = new System.Windows.Forms.MenuStrip();
            this.mstpItemNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSemana = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.GrupBox.SuspendLayout();
            this.mstpMenuMaestro.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrupBox
            // 
            this.GrupBox.Controls.Add(this.TableLayoutPanel1);
            this.GrupBox.Location = new System.Drawing.Point(12, 27);
            this.GrupBox.Size = new System.Drawing.Size(577, 448);
            // 
            // mstpMenuMaestro
            // 
            this.mstpMenuMaestro.BackColor = System.Drawing.Color.Transparent;
            this.mstpMenuMaestro.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstpItemNuevo,
            this.mstpItemBuscar,
            this.mstpItemModificar,
            this.mstpItemGuardar,
            this.mstpItemCancelar,
            this.mstpItemSalir});
            this.mstpMenuMaestro.Location = new System.Drawing.Point(0, 0);
            this.mstpMenuMaestro.Name = "mstpMenuMaestro";
            this.mstpMenuMaestro.ShowItemToolTips = true;
            this.mstpMenuMaestro.Size = new System.Drawing.Size(601, 24);
            this.mstpMenuMaestro.TabIndex = 8;
            this.mstpMenuMaestro.Text = "MenuStrip1";
            // 
            // mstpItemNuevo
            // 
            this.mstpItemNuevo.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemNuevo.Image")));
            this.mstpItemNuevo.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemNuevo.Name = "mstpItemNuevo";
            this.mstpItemNuevo.Size = new System.Drawing.Size(55, 20);
            this.mstpItemNuevo.Text = "(F7)";
            this.mstpItemNuevo.ToolTipText = "Nuevo";
            this.mstpItemNuevo.Click += new System.EventHandler(this.mstpItemNuevo_Click);
            // 
            // mstpItemBuscar
            // 
            this.mstpItemBuscar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemBuscar.Image")));
            this.mstpItemBuscar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemBuscar.Name = "mstpItemBuscar";
            this.mstpItemBuscar.Size = new System.Drawing.Size(55, 20);
            this.mstpItemBuscar.Text = "(F8)";
            this.mstpItemBuscar.ToolTipText = "Buscar";
            this.mstpItemBuscar.Click += new System.EventHandler(this.mstpItemBuscar_Click);
            // 
            // mstpItemModificar
            // 
            this.mstpItemModificar.Enabled = false;
            this.mstpItemModificar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemModificar.Image")));
            this.mstpItemModificar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemModificar.Name = "mstpItemModificar";
            this.mstpItemModificar.Size = new System.Drawing.Size(55, 20);
            this.mstpItemModificar.Text = "(F9)";
            this.mstpItemModificar.ToolTipText = "Modificar";
            this.mstpItemModificar.Click += new System.EventHandler(this.mstpItemModificar_Click);
            // 
            // mstpItemGuardar
            // 
            this.mstpItemGuardar.Enabled = false;
            this.mstpItemGuardar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemGuardar.Image")));
            this.mstpItemGuardar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemGuardar.Name = "mstpItemGuardar";
            this.mstpItemGuardar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemGuardar.Text = "(F10)";
            this.mstpItemGuardar.ToolTipText = "Guardar";
            this.mstpItemGuardar.Click += new System.EventHandler(this.mstpItemGuardar_Click);
            // 
            // mstpItemCancelar
            // 
            this.mstpItemCancelar.Enabled = false;
            this.mstpItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemCancelar.Image")));
            this.mstpItemCancelar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemCancelar.Name = "mstpItemCancelar";
            this.mstpItemCancelar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemCancelar.Text = "(F12)";
            this.mstpItemCancelar.ToolTipText = "Cancelar";
            this.mstpItemCancelar.Click += new System.EventHandler(this.mstpItemCancelar_Click);
            // 
            // mstpItemSalir
            // 
            this.mstpItemSalir.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemSalir.Image")));
            this.mstpItemSalir.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemSalir.Name = "mstpItemSalir";
            this.mstpItemSalir.Size = new System.Drawing.Size(59, 20);
            this.mstpItemSalir.Text = "(Esc)";
            this.mstpItemSalir.ToolTipText = "Salir";
            this.mstpItemSalir.Click += new System.EventHandler(this.mstpItemSalir_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 4;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.txtCodigo, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label3, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.txtDesde, 1, 4);
            this.TableLayoutPanel1.Controls.Add(this.txtHasta, 1, 5);
            this.TableLayoutPanel1.Controls.Add(this.cmbCliente, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.cmbProducto, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.TableLayoutPanel1.Controls.Add(this.txtHora, 1, 6);
            this.TableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.TableLayoutPanel1.Controls.Add(this.txtDia, 1, 7);
            this.TableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.TableLayoutPanel1.Controls.Add(this.txtSemana, 1, 8);
            this.TableLayoutPanel1.Controls.Add(this.label9, 0, 9);
            this.TableLayoutPanel1.Controls.Add(this.txtPrecio, 1, 9);
            this.TableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.TableLayoutPanel1.Controls.Add(this.cmbEstatus, 1, 10);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 12;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.Size = new System.Drawing.Size(565, 423);
            this.TableLayoutPanel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(38, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hasta (*)";
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(46, 6);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Codido";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(34, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Cliente (*)";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(92, 3);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(152, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Location = new System.Drawing.Point(23, 60);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Producto (*)";
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(35, 86);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(51, 13);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Desde (*)";
            // 
            // txtDesde
            // 
            this.txtDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtDesde, 3);
            this.txtDesde.Enabled = false;
            this.txtDesde.Location = new System.Drawing.Point(92, 83);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(470, 20);
            this.txtDesde.TabIndex = 7;
            // 
            // txtHasta
            // 
            this.txtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtHasta, 3);
            this.txtHasta.Enabled = false;
            this.txtHasta.Location = new System.Drawing.Point(92, 109);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(470, 20);
            this.txtHasta.TabIndex = 9;
            // 
            // cmbCliente
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.cmbCliente, 3);
            this.cmbCliente.Enabled = false;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(92, 29);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(468, 21);
            this.cmbCliente.TabIndex = 10;
            // 
            // cmbProducto
            // 
            this.TableLayoutPanel1.SetColumnSpan(this.cmbProducto, 3);
            this.cmbProducto.Enabled = false;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(92, 56);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(468, 21);
            this.cmbProducto.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(56, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hora";
            // 
            // txtHora
            // 
            this.txtHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(92, 135);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(152, 20);
            this.txtHora.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(61, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Día";
            // 
            // txtDia
            // 
            this.txtDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDia.Enabled = false;
            this.txtDia.Location = new System.Drawing.Point(92, 161);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(152, 20);
            this.txtDia.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(40, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Semana";
            // 
            // txtSemana
            // 
            this.txtSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSemana.Enabled = false;
            this.txtSemana.Location = new System.Drawing.Point(92, 187);
            this.txtSemana.Name = "txtSemana";
            this.txtSemana.Size = new System.Drawing.Size(152, 20);
            this.txtSemana.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Precio Esrimado";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(92, 213);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(152, 20);
            this.txtPrecio.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(44, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Estatus";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.Enabled = false;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(92, 239);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(152, 21);
            this.cmbEstatus.TabIndex = 22;
            // 
            // frmAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 487);
            this.Controls.Add(this.mstpMenuMaestro);
            this.Name = "frmAlquiler";
            this.Text = "frmAlquiler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlquiler_FormClosing);
            this.Load += new System.EventHandler(this.frmAlquiler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAlquiler_KeyDown);
            this.Controls.SetChildIndex(this.mstpMenuMaestro, 0);
            this.Controls.SetChildIndex(this.GrupBox, 0);
            this.GrupBox.ResumeLayout(false);
            this.mstpMenuMaestro.ResumeLayout(false);
            this.mstpMenuMaestro.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip mstpMenuMaestro;
        public System.Windows.Forms.ToolStripMenuItem mstpItemNuevo;
        public System.Windows.Forms.ToolStripMenuItem mstpItemBuscar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemModificar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemGuardar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemCancelar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSalir;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtDesde;
        internal System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbProducto;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtHora;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtDia;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtSemana;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtPrecio;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEstatus;

    }
}