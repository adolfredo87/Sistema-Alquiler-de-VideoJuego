namespace Presentacion.Maestros
{
    partial class frmCliente 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.mstpMenuMaestro = new System.Windows.Forms.MenuStrip();
            this.mstpItemNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
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
            this.mstpItemEliminar,
            this.mstpItemCancelar,
            this.mstpItemSalir});
            this.mstpMenuMaestro.Location = new System.Drawing.Point(0, 0);
            this.mstpMenuMaestro.Name = "mstpMenuMaestro";
            this.mstpMenuMaestro.ShowItemToolTips = true;
            this.mstpMenuMaestro.Size = new System.Drawing.Size(601, 24);
            this.mstpMenuMaestro.TabIndex = 6;
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
            // mstpItemEliminar
            // 
            this.mstpItemEliminar.Enabled = false;
            this.mstpItemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemEliminar.Image")));
            this.mstpItemEliminar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemEliminar.Name = "mstpItemEliminar";
            this.mstpItemEliminar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemEliminar.Text = "(F11)";
            this.mstpItemEliminar.ToolTipText = "Eliminar";
            this.mstpItemEliminar.Click += new System.EventHandler(this.mstpItemEliminar_Click);
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
            this.TableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.TableLayoutPanel1.Controls.Add(this.Label1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Label2, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.txtCodigo, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.txtNombre, 1, 2);
            this.TableLayoutPanel1.Controls.Add(this.Label4, 0, 3);
            this.TableLayoutPanel1.Controls.Add(this.Label7, 0, 4);
            this.TableLayoutPanel1.Controls.Add(this.txtTelefono, 1, 3);
            this.TableLayoutPanel1.Controls.Add(this.txtCorreo, 1, 4);
            this.TableLayoutPanel1.Controls.Add(this.txtDireccion, 1, 5);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 7;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel1.Size = new System.Drawing.Size(565, 423);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Direccion (*)";
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(28, 6);
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
            this.Label2.Location = new System.Drawing.Point(11, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Nombre (*)";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(74, 3);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(158, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtNombre, 3);
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(74, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(488, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Location = new System.Drawing.Point(6, 58);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(62, 13);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Telefono (*)";
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Location = new System.Drawing.Point(17, 84);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Correo (*)";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtTelefono, 3);
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(74, 55);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTelefono.Size = new System.Drawing.Size(488, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtCorreo, 3);
            this.txtCorreo.Enabled = false;
            this.txtCorreo.Location = new System.Drawing.Point(74, 81);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(488, 20);
            this.txtCorreo.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.SetColumnSpan(this.txtDireccion, 3);
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(74, 107);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(488, 48);
            this.txtDireccion.TabIndex = 9;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(601, 487);
            this.Controls.Add(this.mstpMenuMaestro);
            this.Name = "frmCliente";
            this.Text = "Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCliente_FormClosing);
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCliente_KeyDown);
            this.Controls.SetChildIndex(this.GrupBox, 0);
            this.Controls.SetChildIndex(this.mstpMenuMaestro, 0);
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
        public System.Windows.Forms.ToolStripMenuItem mstpItemEliminar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemCancelar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSalir;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtTelefono;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtCorreo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtDireccion;
    }
}