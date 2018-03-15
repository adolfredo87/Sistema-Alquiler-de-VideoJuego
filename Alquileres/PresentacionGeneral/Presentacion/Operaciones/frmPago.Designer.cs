namespace Presentacion.Operaciones
{
    partial class frmPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPago));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mstpMenuMaestro = new System.Windows.Forms.MenuStrip();
            this.mstpItemNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCabecera = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.Label6 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mstpInsSupr = new System.Windows.Forms.MenuStrip();
            this.mstpItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSupr = new System.Windows.Forms.ToolStripMenuItem();
            this.dgDetalle = new System.Windows.Forms.DataGridView();
            this.colProducto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMontoExento = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GrupBox.SuspendLayout();
            this.mstpMenuMaestro.SuspendLayout();
            this.gbCabecera.SuspendLayout();
            this.TableLayoutPanel7.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.mstpInsSupr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).BeginInit();
            this.TableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrupBox
            // 
            this.GrupBox.Controls.Add(this.gbCabecera);
            this.GrupBox.Controls.Add(this.gbDetalle);
            this.GrupBox.Location = new System.Drawing.Point(12, 27);
            this.GrupBox.Size = new System.Drawing.Size(597, 448);
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
            this.mstpMenuMaestro.Size = new System.Drawing.Size(621, 24);
            this.mstpMenuMaestro.TabIndex = 6;
            this.mstpMenuMaestro.Text = "MenuStrip1";
            // 
            // mstpItemNuevo
            // 
            this.mstpItemNuevo.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemNuevo.Image")));
            this.mstpItemNuevo.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemNuevo.Name = "mstpItemNuevo";
            this.mstpItemNuevo.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mstpItemNuevo.Size = new System.Drawing.Size(55, 20);
            this.mstpItemNuevo.Text = "(F7)";
            this.mstpItemNuevo.ToolTipText = "Nuevo";
            // 
            // mstpItemBuscar
            // 
            this.mstpItemBuscar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemBuscar.Image")));
            this.mstpItemBuscar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemBuscar.Name = "mstpItemBuscar";
            this.mstpItemBuscar.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mstpItemBuscar.Size = new System.Drawing.Size(55, 20);
            this.mstpItemBuscar.Text = "(F8)";
            this.mstpItemBuscar.ToolTipText = "Buscar";
            // 
            // mstpItemModificar
            // 
            this.mstpItemModificar.Enabled = false;
            this.mstpItemModificar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemModificar.Image")));
            this.mstpItemModificar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemModificar.Name = "mstpItemModificar";
            this.mstpItemModificar.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.mstpItemModificar.Size = new System.Drawing.Size(55, 20);
            this.mstpItemModificar.Text = "(F9)";
            this.mstpItemModificar.ToolTipText = "Modificar";
            // 
            // mstpItemGuardar
            // 
            this.mstpItemGuardar.Enabled = false;
            this.mstpItemGuardar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemGuardar.Image")));
            this.mstpItemGuardar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemGuardar.Name = "mstpItemGuardar";
            this.mstpItemGuardar.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mstpItemGuardar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemGuardar.Text = "(F10)";
            this.mstpItemGuardar.ToolTipText = "Guardar";
            // 
            // mstpItemEliminar
            // 
            this.mstpItemEliminar.Enabled = false;
            this.mstpItemEliminar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemEliminar.Image")));
            this.mstpItemEliminar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemEliminar.Name = "mstpItemEliminar";
            this.mstpItemEliminar.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.mstpItemEliminar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemEliminar.Text = "(F11)";
            this.mstpItemEliminar.ToolTipText = "Eliminar";
            // 
            // mstpItemCancelar
            // 
            this.mstpItemCancelar.Enabled = false;
            this.mstpItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemCancelar.Image")));
            this.mstpItemCancelar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemCancelar.Name = "mstpItemCancelar";
            this.mstpItemCancelar.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mstpItemCancelar.Size = new System.Drawing.Size(61, 20);
            this.mstpItemCancelar.Text = "(F12)";
            this.mstpItemCancelar.ToolTipText = "Cancelar";
            // 
            // mstpItemSalir
            // 
            this.mstpItemSalir.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemSalir.Image")));
            this.mstpItemSalir.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemSalir.Name = "mstpItemSalir";
            this.mstpItemSalir.Size = new System.Drawing.Size(59, 20);
            this.mstpItemSalir.Text = "(Esc)";
            this.mstpItemSalir.ToolTipText = "Salir";
            // 
            // gbCabecera
            // 
            this.gbCabecera.BackColor = System.Drawing.Color.Transparent;
            this.gbCabecera.Controls.Add(this.TableLayoutPanel7);
            this.gbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCabecera.Location = new System.Drawing.Point(3, 16);
            this.gbCabecera.Name = "gbCabecera";
            this.gbCabecera.Size = new System.Drawing.Size(591, 120);
            this.gbCabecera.TabIndex = 1;
            this.gbCabecera.TabStop = false;
            this.gbCabecera.Text = "Datos Cabecera";
            // 
            // TableLayoutPanel7
            // 
            this.TableLayoutPanel7.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel7.ColumnCount = 4;
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanel7.Controls.Add(this.txtDescuento, 0, 3);
            this.TableLayoutPanel7.Controls.Add(this.label4, 0, 3);
            this.TableLayoutPanel7.Controls.Add(this.txtID, 1, 1);
            this.TableLayoutPanel7.Controls.Add(this.cmbCliente, 1, 0);
            this.TableLayoutPanel7.Controls.Add(this.Label2, 0, 0);
            this.TableLayoutPanel7.Controls.Add(this.Label3, 0, 2);
            this.TableLayoutPanel7.Controls.Add(this.Label1, 0, 1);
            this.TableLayoutPanel7.Controls.Add(this.dtpFecha, 1, 2);
            this.TableLayoutPanel7.Controls.Add(this.Label6, 2, 1);
            this.TableLayoutPanel7.Controls.Add(this.cmbEstatus, 3, 1);
            this.TableLayoutPanel7.Controls.Add(this.Label5, 2, 3);
            this.TableLayoutPanel7.Controls.Add(this.txtTotal, 3, 3);
            this.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
            this.TableLayoutPanel7.Name = "TableLayoutPanel7";
            this.TableLayoutPanel7.RowCount = 4;
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.78571F));
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.21429F));
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel7.Size = new System.Drawing.Size(585, 101);
            this.TableLayoutPanel7.TabIndex = 0;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Location = new System.Drawing.Point(68, 78);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(318, 20);
            this.txtDescuento.TabIndex = 13;
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Descuento";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(68, 29);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(318, 20);
            this.txtID.TabIndex = 3;
            this.txtID.Text = " ";
            // 
            // cmbCliente
            // 
            this.cmbCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(68, 3);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(318, 21);
            this.cmbCliente.TabIndex = 1;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Location = new System.Drawing.Point(23, 6);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(39, 13);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Cliente";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Location = new System.Drawing.Point(25, 56);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(37, 13);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "Fecha";
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Location = new System.Drawing.Point(15, 31);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 13);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "N° Pago";
            // 
            // dtpFecha
            // 
            this.dtpFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(214)))), ((int)(((byte)(239)))));
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFecha.Location = new System.Drawing.Point(68, 53);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(318, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Location = new System.Drawing.Point(414, 31);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 13);
            this.Label6.TabIndex = 4;
            this.Label6.Text = "Estatus";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(462, 29);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(120, 21);
            this.cmbEstatus.TabIndex = 5;
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Location = new System.Drawing.Point(392, 81);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 13);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Monto Total";
            // 
            // txtTotal
            // 
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(462, 78);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(120, 20);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.BackColor = System.Drawing.Color.Transparent;
            this.gbDetalle.Controls.Add(this.TableLayoutPanel1);
            this.gbDetalle.Location = new System.Drawing.Point(6, 136);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(588, 312);
            this.gbDetalle.TabIndex = 2;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Datos Deatlle";
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.mstpInsSupr, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.dgDetalle, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel8, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.19009F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.80992F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(582, 293);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // mstpInsSupr
            // 
            this.mstpInsSupr.BackColor = System.Drawing.Color.Transparent;
            this.mstpInsSupr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mstpInsSupr.Enabled = false;
            this.mstpInsSupr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstpItemInsert,
            this.mstpItemSupr});
            this.mstpInsSupr.Location = new System.Drawing.Point(0, 196);
            this.mstpInsSupr.Name = "mstpInsSupr";
            this.mstpInsSupr.Size = new System.Drawing.Size(582, 28);
            this.mstpInsSupr.TabIndex = 15;
            this.mstpInsSupr.Text = "MenuStrip2";
            // 
            // mstpItemInsert
            // 
            this.mstpItemInsert.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemInsert.Image")));
            this.mstpItemInsert.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemInsert.Name = "mstpItemInsert";
            this.mstpItemInsert.Size = new System.Drawing.Size(72, 24);
            this.mstpItemInsert.Text = "(Insert)";
            // 
            // mstpItemSupr
            // 
            this.mstpItemSupr.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemSupr.Image")));
            this.mstpItemSupr.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemSupr.Name = "mstpItemSupr";
            this.mstpItemSupr.Size = new System.Drawing.Size(65, 24);
            this.mstpItemSupr.Text = "(Supr)";
            // 
            // dgDetalle
            // 
            this.dgDetalle.AllowUserToAddRows = false;
            this.dgDetalle.AllowUserToResizeRows = false;
            this.dgDetalle.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colDesde,
            this.colHasta,
            this.colPrecio});
            this.dgDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalle.Location = new System.Drawing.Point(3, 3);
            this.dgDetalle.Name = "dgDetalle";
            this.dgDetalle.RowHeadersVisible = false;
            this.dgDetalle.Size = new System.Drawing.Size(576, 190);
            this.dgDetalle.TabIndex = 0;
            // 
            // colProducto
            // 
            this.colProducto.DataPropertyName = "IDProducto";
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            this.colProducto.Width = 200;
            // 
            // colDesde
            // 
            this.colDesde.DataPropertyName = "FechaDesde";
            this.colDesde.HeaderText = "Desde";
            this.colDesde.Name = "colDesde";
            this.colDesde.Width = 140;
            // 
            // colHasta
            // 
            this.colHasta.DataPropertyName = "FechaHasta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colHasta.DefaultCellStyle = dataGridViewCellStyle1;
            this.colHasta.HeaderText = "Hasta";
            this.colHasta.Name = "colHasta";
            this.colHasta.Width = 140;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "PrecioEstimado";
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.Width = 90;
            // 
            // TableLayoutPanel8
            // 
            this.TableLayoutPanel8.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel8.ColumnCount = 2;
            this.TableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel8.Controls.Add(this.lblTotal, 1, 1);
            this.TableLayoutPanel8.Controls.Add(this.lblMontoExento, 1, 0);
            this.TableLayoutPanel8.Controls.Add(this.Label8, 0, 0);
            this.TableLayoutPanel8.Controls.Add(this.Label7, 0, 1);
            this.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.TableLayoutPanel8.Location = new System.Drawing.Point(377, 227);
            this.TableLayoutPanel8.Name = "TableLayoutPanel8";
            this.TableLayoutPanel8.RowCount = 2;
            this.TableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel8.Size = new System.Drawing.Size(202, 63);
            this.TableLayoutPanel8.TabIndex = 13;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(104, 34);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(95, 26);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMontoExento
            // 
            this.lblMontoExento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMontoExento.BackColor = System.Drawing.Color.Transparent;
            this.lblMontoExento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMontoExento.Location = new System.Drawing.Point(104, 5);
            this.lblMontoExento.Name = "lblMontoExento";
            this.lblMontoExento.Size = new System.Drawing.Size(95, 21);
            this.lblMontoExento.TabIndex = 1;
            this.lblMontoExento.Text = "0,00";
            this.lblMontoExento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label8
            // 
            this.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Location = new System.Drawing.Point(25, 9);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(73, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Monto Exento";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(23, 40);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(75, 13);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Monto Total";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 487);
            this.Controls.Add(this.mstpMenuMaestro);
            this.Name = "frmPago";
            this.Text = "frmPago";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPago_FormClosing);
            this.Load += new System.EventHandler(this.frmPago_Load);
            this.Controls.SetChildIndex(this.mstpMenuMaestro, 0);
            this.Controls.SetChildIndex(this.GrupBox, 0);
            this.GrupBox.ResumeLayout(false);
            this.mstpMenuMaestro.ResumeLayout(false);
            this.mstpMenuMaestro.PerformLayout();
            this.gbCabecera.ResumeLayout(false);
            this.TableLayoutPanel7.ResumeLayout(false);
            this.TableLayoutPanel7.PerformLayout();
            this.gbDetalle.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.mstpInsSupr.ResumeLayout(false);
            this.mstpInsSupr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalle)).EndInit();
            this.TableLayoutPanel8.ResumeLayout(false);
            this.TableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox gbCabecera;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel7;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.ComboBox cmbCliente;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker dtpFecha;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cmbEstatus;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.GroupBox gbDetalle;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView dgDetalle;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel8;
        internal System.Windows.Forms.Label lblTotal;
        internal System.Windows.Forms.Label lblMontoExento;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.MenuStrip mstpMenuMaestro;
        public System.Windows.Forms.ToolStripMenuItem mstpItemNuevo;
        public System.Windows.Forms.ToolStripMenuItem mstpItemBuscar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemModificar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemGuardar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemEliminar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemCancelar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSalir;
        internal System.Windows.Forms.TextBox txtDescuento;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.MenuStrip mstpInsSupr;
        public System.Windows.Forms.ToolStripMenuItem mstpItemInsert;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSupr;
        private System.Windows.Forms.DataGridViewComboBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;

    }
}