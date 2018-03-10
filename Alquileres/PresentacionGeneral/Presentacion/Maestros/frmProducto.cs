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
    public partial class frmProducto : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.ProductoController _ctrlProducto = new LogicaNegocio.ProductoController();
        private List<EntidadNegocio.Entidades.Producto> _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
        private List<EntidadNegocio.Entidades.CategoriaProducto> _lstCategoriaProducto = new List<EntidadNegocio.Entidades.CategoriaProducto>();
        private LogicaNegocio.CategoriaProductoController _ctrlCategoriaProducto = new LogicaNegocio.CategoriaProductoController();
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

        public frmProducto()
        {
            InitializeComponent();
        }
        private void CargarProductos()
        {
            try
            {
                _lstProductos = _ctrlProducto.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarProductos()
        {
            try
            {
                dgProductos.AutoGenerateColumns = false;
                dgProductos.DataSource = null;
                dgProductos.DataSource = _lstProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ObtenerCategoriaProducto()
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
        private void CargarComboCategoriaProducto() 
        {
            try
            {
                ObtenerCategoriaProducto();
                CargarProductos();
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgProductos.Columns["colCategoria"]);
                column.DisplayMember = "Categoria";
                column.ValueMember = "ID";
                column.DataSource = (from cp in _lstCategoriaProducto select cp).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AñadirProducto()
        {
            try
            {
                EntidadNegocio.Entidades.Producto _Producto = new EntidadNegocio.Entidades.Producto();
                _Producto.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Producto.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstProductos.Count == 0) _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
                _lstProductos.Add(_Producto);
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarProducto()
        {
            try
            {
                if (_lstProductos.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstProductos.Count != 0)
                    {
                        if (_ctrlProducto.DatosValidos(_lstProductos))
                        {
                            if (_ctrlProducto.Guardar(_lstProductos))
                            {
                                //Se elimina el Producto
                            }
                        }
                    }
                    else
                    {
                        _lstProductos.Remove(((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem));
                    }
                }
                CargarProductos();
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarProductos()
        {
            try
            {
                dgProductos.EndEdit();
                if (_ctrlProducto.Guardar(_lstProductos))
                {
                    CargarProductos();
                    MostrarProductos();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgProductos.Focus();
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
                    if (MenuInsert != null) MenuInsert(mstpItemInsert, null); ;
                    break;
                case System.Windows.Forms.Keys.Delete:
                    if (MenuSuprimir != null) MenuSuprimir(mstpItemSupr, null); ;
                    break;
                case System.Windows.Forms.Keys.F10:
                    if (MenuGuardar != null) MenuGuardar(mstpItemGuardar, null); ;
                    break;
                case System.Windows.Forms.Keys.F12:
                    if (MenuCancelar != null) MenuCancelar(mstpItemCancelar, null); ;
                    break;
                case System.Windows.Forms.Keys.Escape:
                    if (MenuSalir != null) MenuSalir(mstpItemSalir, null); ;
                    break;
            }
        }
        private void frmProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Producto";
                this.Text = "Producto";
                CargarComboCategoriaProducto();
                CargarProductos();
                MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgProductos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlProducto.DatoDuplicado(_lstProductos, ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlCategoriaProducto.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Producto)dgProductos.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgProductos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirProducto();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarProductos();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarProductos(); MostrarProductos();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmProducto_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgProductos.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgProductos.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgProductos.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgProductos.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgProductos, e, dgProductos.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
