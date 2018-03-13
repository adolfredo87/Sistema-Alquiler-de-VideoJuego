using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Maestros
{
    public partial class frmCategoria : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.CategoriaController _ctrlCategoria = new LogicaNegocio.CategoriaController();
        private EntidadNegocio.Entidades.Categoria _categoria = new EntidadNegocio.Entidades.Categoria();
        private List<EntidadNegocio.Entidades.Categoria> _lstCategoria = new List<EntidadNegocio.Entidades.Categoria>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Categoria _categoria);
        public event GuardarEventHandler Guardar;
        #endregion

        #region "Eventos"
        internal delegate void MenuInsertEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuInsertEventHandler MenuInsert;
        internal delegate void MenuSuprimirEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuSuprimirEventHandler MenuSuprimir;
        internal delegate void MenuGuardarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuGuardarEventHandler MenuGuardar;
        internal delegate void MenuCancelarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuCancelarEventHandler MenuCancelar;
        internal delegate void MenuSalirEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuSalirEventHandler MenuSalir;
        #endregion

        public frmCategoria()
        {
            InitializeComponent();
        }
        private void CargarCategoria()
        {
            try
            {
                _lstCategoria = _ctrlCategoria.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarCategoria()
        {
            try
            {
                dgCategoria.AutoGenerateColumns = false;
                dgCategoria.DataSource = null;
                dgCategoria.DataSource = _lstCategoria;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarComboGridEstatus()
        {
            try
            {
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgCategoria.Columns["colEstatus"]);
                List<EntidadNegocio.Entidades.EstatusRegistro> l = new List<EntidadNegocio.Entidades.EstatusRegistro>();
                int[] values = ((int[])Enum.GetValues(typeof(EntidadNegocio.Enumerados.EnumEstatus.Registro)));
                EntidadNegocio.Entidades.EstatusRegistro i;
                foreach (int value in values)
                {
                    i = new EntidadNegocio.Entidades.EstatusRegistro();
                    i.Descripcion = Enum.GetName(typeof(EntidadNegocio.Enumerados.EnumEstatus.Registro), value);
                    i.Estatus = value;
                    l.Add(i);
                }
                column.DataSource = l;
                column.DisplayMember = "Descripcion";
                column.ValueMember = "Estatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AñadirCategoria()
        {
            try
            {
                EntidadNegocio.Entidades.Categoria _Categoria = new EntidadNegocio.Entidades.Categoria();
                _Categoria.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Categoria.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstCategoria.Count == 0) _lstCategoria = new List<EntidadNegocio.Entidades.Categoria>();
                _lstCategoria.Add(_Categoria);
                MostrarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarCategoria()
        {
            try
            {
                if (_lstCategoria.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstCategoria.Count != 0)
                    {
                        if (_ctrlCategoria.DatosValidos(_lstCategoria))
                        {
                            if (_ctrlCategoria.Guardar(_lstCategoria))
                            {
                                //Se elimina la categoria del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstCategoria.Remove(((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem));
                    }
                }
                CargarCategoria();
                MostrarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarCategoria()
        {
            try
            {
                dgCategoria.EndEdit();
                if (_ctrlCategoria.Guardar(_lstCategoria))
                {
                    CargarCategoria();
                    MostrarCategoria();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgCategoria.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TeclaPresionada(System.Windows.Forms.Keys Tecla)
        {
            switch (Tecla)
            {
                case System.Windows.Forms.Keys.Insert:
                    if (MenuInsert != null) MenuInsert(mstpItemInsert, null);;
                    break;
                case System.Windows.Forms.Keys.Delete:
                    if (MenuSuprimir != null) MenuSuprimir(mstpItemSupr, null);;
                    break;
                case System.Windows.Forms.Keys.F10:
                    if (MenuGuardar != null) MenuGuardar(mstpItemGuardar, null);;
                    break;
                case System.Windows.Forms.Keys.F12:
                    if (MenuCancelar != null) MenuCancelar(mstpItemCancelar, null);;
                    break;
                case System.Windows.Forms.Keys.Escape:
                    if (MenuSalir != null) MenuSalir(mstpItemSalir, null);;
                    break;
            }
        }
        private void frmCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Categoria";
                this.Text = "Categoria";
                LlenarComboGridEstatus();
                CargarCategoria();
                MostrarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgCategoria_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgCategoria_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlCategoria.DatoDuplicado(_lstCategoria, ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlCategoria.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Categoria)dgCategoria.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgCategoria.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirCategoria();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarCategoria();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarCategoria();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarCategoria(); MostrarCategoria();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgCategoria_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgCategoria.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgCategoria, e, dgCategoria.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgCategoria.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgCategoria, e, dgCategoria.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgCategoria.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgCategoria, e, dgCategoria.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgCategoria.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgCategoria, e, dgCategoria.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
