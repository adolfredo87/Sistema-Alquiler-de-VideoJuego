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
    public partial class frmPrecio : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.PrecioController _ctrlPrecio = new LogicaNegocio.PrecioController();
        private EntidadNegocio.Entidades.Precio _precio = new EntidadNegocio.Entidades.Precio();
        private List<EntidadNegocio.Entidades.Precio> _lstPrecio = new List<EntidadNegocio.Entidades.Precio>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Precio _precio);
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

        public frmPrecio()
        {
            InitializeComponent();
        }
        private void CargarPrecio()
        {
            try
            {
                _lstPrecio = _ctrlPrecio.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarPrecio()
        {
            try
            {
                dgPrecio.AutoGenerateColumns = false;
                dgPrecio.DataSource = null;
                dgPrecio.DataSource = _lstPrecio;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AñadirPrecio()
        {
            try
            {
                EntidadNegocio.Entidades.Precio _Precio = new EntidadNegocio.Entidades.Precio();
                _Precio.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Precio.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstPrecio.Count == 0) _lstPrecio = new List<EntidadNegocio.Entidades.Precio>();
                _lstPrecio.Add(_Precio);
                MostrarPrecio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarPrecio()
        {
            try
            {
                if (_lstPrecio.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstPrecio.Count != 0)
                    {
                        if (_ctrlPrecio.DatosValidos(_lstPrecio))
                        {
                            if (_ctrlPrecio.Guardar(_lstPrecio))
                            {
                                //Se elimina la categoria del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstPrecio.Remove(((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem));
                    }
                }
                CargarPrecio();
                MostrarPrecio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarPrecio()
        {
            try
            {
                dgPrecio.EndEdit();
                if (_ctrlPrecio.Guardar(_lstPrecio))
                {
                    CargarPrecio();
                    MostrarPrecio();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgPrecio.Focus();
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
        private void frmPrecio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmPrecio_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Precio";
                this.Text = "Precio";
                CargarPrecio();
                MostrarPrecio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgPrecio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgPrecio_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlPrecio.DatoDuplicado(_lstPrecio, ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlPrecio.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Precio)dgPrecio.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgPrecio.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirPrecio();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarPrecio();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarPrecio();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarPrecio(); MostrarPrecio();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgPrecio_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgPrecio.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgPrecio, e, dgPrecio.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgPrecio.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgPrecio, e, dgPrecio.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgPrecio.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgPrecio, e, dgPrecio.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgPrecio.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgPrecio, e, dgPrecio.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
