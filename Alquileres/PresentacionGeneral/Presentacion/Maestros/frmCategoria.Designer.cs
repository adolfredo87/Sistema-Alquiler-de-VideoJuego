﻿namespace Presentacion.Maestros
{
    partial class frmCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoria));
            this.mstpGuardarCancelar = new System.Windows.Forms.MenuStrip();
            this.mstpItemGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpInsSupr = new System.Windows.Forms.MenuStrip();
            this.mstpItemInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mstpItemSupr = new System.Windows.Forms.ToolStripMenuItem();
            this.dgCategoria = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoddigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GrupBox.SuspendLayout();
            this.mstpGuardarCancelar.SuspendLayout();
            this.mstpInsSupr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // GrupBox
            // 
            this.GrupBox.Controls.Add(this.dgCategoria);
            this.GrupBox.Location = new System.Drawing.Point(12, 27);
            this.GrupBox.Size = new System.Drawing.Size(597, 433);
            this.GrupBox.Text = "Categoria";
            // 
            // mstpGuardarCancelar
            // 
            this.mstpGuardarCancelar.BackColor = System.Drawing.Color.Transparent;
            this.mstpGuardarCancelar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstpItemGuardar,
            this.mstpItemCancelar,
            this.mstpItemSalir});
            this.mstpGuardarCancelar.Location = new System.Drawing.Point(0, 0);
            this.mstpGuardarCancelar.Name = "mstpGuardarCancelar";
            this.mstpGuardarCancelar.Size = new System.Drawing.Size(621, 24);
            this.mstpGuardarCancelar.TabIndex = 1;
            this.mstpGuardarCancelar.Text = "MenuStrip2";
            // 
            // mstpItemGuardar
            // 
            this.mstpItemGuardar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemGuardar.Image")));
            this.mstpItemGuardar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemGuardar.Name = "mstpItemGuardar";
            this.mstpItemGuardar.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mstpItemGuardar.Size = new System.Drawing.Size(103, 20);
            this.mstpItemGuardar.Text = "Guardar (F10)";
            this.mstpItemGuardar.Click += new System.EventHandler(this.mstpItemGuardar_Click);
            // 
            // mstpItemCancelar
            // 
            this.mstpItemCancelar.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemCancelar.Image")));
            this.mstpItemCancelar.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemCancelar.Name = "mstpItemCancelar";
            this.mstpItemCancelar.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mstpItemCancelar.Size = new System.Drawing.Size(106, 20);
            this.mstpItemCancelar.Text = "Cancelar (F12)";
            this.mstpItemCancelar.Click += new System.EventHandler(this.mstpItemCancelar_Click);
            // 
            // mstpItemSalir
            // 
            this.mstpItemSalir.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemSalir.Image")));
            this.mstpItemSalir.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemSalir.Name = "mstpItemSalir";
            this.mstpItemSalir.Size = new System.Drawing.Size(82, 20);
            this.mstpItemSalir.Text = "Salir (Esc)";
            this.mstpItemSalir.Click += new System.EventHandler(this.mstpItemSalir_Click);
            // 
            // mstpInsSupr
            // 
            this.mstpInsSupr.BackColor = System.Drawing.Color.Transparent;
            this.mstpInsSupr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mstpInsSupr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mstpItemInsert,
            this.mstpItemSupr});
            this.mstpInsSupr.Location = new System.Drawing.Point(0, 463);
            this.mstpInsSupr.Name = "mstpInsSupr";
            this.mstpInsSupr.Size = new System.Drawing.Size(621, 24);
            this.mstpInsSupr.TabIndex = 3;
            this.mstpInsSupr.Text = "MenuStrip2";
            // 
            // mstpItemInsert
            // 
            this.mstpItemInsert.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemInsert.Image")));
            this.mstpItemInsert.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemInsert.Name = "mstpItemInsert";
            this.mstpItemInsert.Size = new System.Drawing.Size(72, 20);
            this.mstpItemInsert.Text = "(Insert)";
            this.mstpItemInsert.Click += new System.EventHandler(this.mstpItemInsert_Click);
            // 
            // mstpItemSupr
            // 
            this.mstpItemSupr.Image = ((System.Drawing.Image)(resources.GetObject("mstpItemSupr.Image")));
            this.mstpItemSupr.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mstpItemSupr.Name = "mstpItemSupr";
            this.mstpItemSupr.Size = new System.Drawing.Size(65, 20);
            this.mstpItemSupr.Text = "(Supr)";
            this.mstpItemSupr.Click += new System.EventHandler(this.mstpItemSupr_Click);
            // 
            // dgCategoria
            // 
            this.dgCategoria.AllowUserToAddRows = false;
            this.dgCategoria.AllowUserToResizeRows = false;
            this.dgCategoria.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCoddigo,
            this.colDescripcion,
            this.colEstatus});
            this.dgCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCategoria.Location = new System.Drawing.Point(3, 16);
            this.dgCategoria.Name = "dgCategoria";
            this.dgCategoria.RowHeadersVisible = false;
            this.dgCategoria.Size = new System.Drawing.Size(591, 414);
            this.dgCategoria.TabIndex = 2;
            this.dgCategoria.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCategoria_CellEndEdit);
            this.dgCategoria.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgCategoria_DataError);
            this.dgCategoria.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgCategoria_EditingControlShowing);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            this.colID.Width = 90;
            // 
            // colCoddigo
            // 
            this.colCoddigo.DataPropertyName = "Codigo";
            this.colCoddigo.HeaderText = "Coddigo";
            this.colCoddigo.Name = "colCoddigo";
            this.colCoddigo.Width = 90;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Width = 350;
            // 
            // colEstatus
            // 
            this.colEstatus.DataPropertyName = "Status";
            this.colEstatus.HeaderText = "Estatus";
            this.colEstatus.Name = "colEstatus";
            this.colEstatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEstatus.Width = 90;
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 487);
            this.Controls.Add(this.mstpInsSupr);
            this.Controls.Add(this.mstpGuardarCancelar);
            this.Name = "frmCategoria";
            this.Text = "frmCategoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCategoria_FormClosing);
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCategoria_KeyDown);
            this.Controls.SetChildIndex(this.GrupBox, 0);
            this.Controls.SetChildIndex(this.mstpGuardarCancelar, 0);
            this.Controls.SetChildIndex(this.mstpInsSupr, 0);
            this.GrupBox.ResumeLayout(false);
            this.mstpGuardarCancelar.ResumeLayout(false);
            this.mstpGuardarCancelar.PerformLayout();
            this.mstpInsSupr.ResumeLayout(false);
            this.mstpInsSupr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip mstpGuardarCancelar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemGuardar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemCancelar;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSalir;
        internal System.Windows.Forms.MenuStrip mstpInsSupr;
        public System.Windows.Forms.ToolStripMenuItem mstpItemInsert;
        public System.Windows.Forms.ToolStripMenuItem mstpItemSupr;
        internal System.Windows.Forms.DataGridView dgCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoddigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEstatus;
    }
}