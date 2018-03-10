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
    public partial class frmCategoriaProducto : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.CategoriaProductoController _ctrlCategoriaProducto = new LogicaNegocio.CategoriaProductoController();
        private EntidadNegocio.Entidades.CategoriaProducto _categoriaProducto = new EntidadNegocio.Entidades.CategoriaProducto();
        private List<EntidadNegocio.Entidades.CategoriaProducto> _lstCategoriaProducto = new List<EntidadNegocio.Entidades.CategoriaProducto>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.CategoriaProducto _categoriaProducto);
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

        public frmCategoriaProducto()
        {
            InitializeComponent();
        }
        private void CargarCategoriaProducto()
        {
            try
            {
                _lstCategoriaProducto = _ctrlCategoriaProducto.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarCategoriaProducto()
        {
            try
            {
                dgCategoriaProducto.AutoGenerateColumns = false;
                dgCategoriaProducto.DataSource = null;
                dgCategoriaProducto.DataSource = _lstCategoriaProducto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AñadirCategoriaProducto()
        {
            try
            {
                EntidadNegocio.Entidades.CategoriaProducto _CategoriaProducto = new EntidadNegocio.Entidades.CategoriaProducto();
                _CategoriaProducto.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _CategoriaProducto.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstCategoriaProducto.Count == 0) _lstCategoriaProducto = new List<EntidadNegocio.Entidades.CategoriaProducto>();
                _lstCategoriaProducto.Add(_CategoriaProducto);
                MostrarCategoriaProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarCategoriaProducto()
        {
            try
            {
                if (_lstCategoriaProducto.Count > 0)
                {
                    ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstCategoriaProducto.Count != 0)
                    {
                        if (_ctrlCategoriaProducto.DatosValidos(_lstCategoriaProducto))
                        {
                            if (_ctrlCategoriaProducto.Guardar(_lstCategoriaProducto))
                            {
                                //Se elimina la categoria del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstCategoriaProducto.Remove(((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem));
                    }
                }
                CargarCategoriaProducto();
                MostrarCategoriaProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarCategoriaProducto()
        {
            try
            {
                dgCategoriaProducto.EndEdit();
                if (_ctrlCategoriaProducto.Guardar(_lstCategoriaProducto))
                {
                    CargarCategoriaProducto();
                    MostrarCategoriaProducto();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgCategoriaProducto.Focus();
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
        private void frmCategoriaProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmCategoriaProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Categoria Producto"; 
                this.Text = "Categoria Producto";
                CargarCategoriaProducto();
                MostrarCategoriaProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgCategoriaProducto_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgCategoriaProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlCategoriaProducto.DatoDuplicado(_lstCategoriaProducto, ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlCategoriaProducto.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.CategoriaProducto)dgCategoriaProducto.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgCategoriaProducto.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirCategoriaProducto();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarCategoriaProducto();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarCategoriaProducto();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarCategoriaProducto(); MostrarCategoriaProducto();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCategoriaProducto_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgCategoriaProducto_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgCategoriaProducto.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgCategoriaProducto, e, dgCategoriaProducto.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgCategoriaProducto.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgCategoriaProducto, e, dgCategoriaProducto.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgCategoriaProducto.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgCategoriaProducto, e, dgCategoriaProducto.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgCategoriaProducto.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgCategoriaProducto, e, dgCategoriaProducto.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
