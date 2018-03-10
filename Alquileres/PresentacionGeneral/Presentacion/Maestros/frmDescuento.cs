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
    public partial class frmDescuento : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.DescuentoController _ctrlDescuento = new LogicaNegocio.DescuentoController();
        private EntidadNegocio.Entidades.Descuento _descuento = new EntidadNegocio.Entidades.Descuento();
        private List<EntidadNegocio.Entidades.Descuento> _lstDescuento = new List<EntidadNegocio.Entidades.Descuento>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Descuento _descuento);
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

        public frmDescuento()
        {
            InitializeComponent();
        }
        private void CargarDescuento()
        {
            try
            {
                _lstDescuento = _ctrlDescuento.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarDescuento()
        {
            try
            {
                dgDescuento.AutoGenerateColumns = false;
                dgDescuento.DataSource = null;
                dgDescuento.DataSource = _lstDescuento;
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
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgDescuento.Columns["colEstatus"]);
                List<EntidadNegocio.Entidades.EstatusRegistro> l = new List<EntidadNegocio.Entidades.EstatusRegistro>();
                int[] values = ((int[])Enum.GetValues(typeof(EntidadNegocio.Enumerados.EnumEstatus.Registro)));
                EntidadNegocio.Entidades.EstatusRegistro i;
                foreach(int value in values)
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
        private void AñadirDescuento()
        {
            try
            {
                EntidadNegocio.Entidades.Descuento _Descuento = new EntidadNegocio.Entidades.Descuento();
                _Descuento.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Descuento.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstDescuento.Count == 0) _lstDescuento = new List<EntidadNegocio.Entidades.Descuento>();
                _lstDescuento.Add(_Descuento);
                MostrarDescuento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarDescuento()
        {
            try
            {
                if (_lstDescuento.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstDescuento.Count != 0)
                    {
                        if (_ctrlDescuento.DatosValidos(_lstDescuento))
                        {
                            if (_ctrlDescuento.Guardar(_lstDescuento))
                            {
                                //Se elimina la categoria del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstDescuento.Remove(((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem));
                    }
                }
                CargarDescuento();
                MostrarDescuento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarDescuento()
        {
            try
            {
                dgDescuento.EndEdit();
                if (_ctrlDescuento.Guardar(_lstDescuento))
                {
                    CargarDescuento();
                    MostrarDescuento();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgDescuento.Focus();
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
        private void frmDescuento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Descuento";
                this.Text = "Descuento";
                LlenarComboGridEstatus();
                CargarDescuento();
                MostrarDescuento();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgDescuento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgDescuento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlDescuento.DatoDuplicado(_lstDescuento, ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlDescuento.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Descuento)dgDescuento.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgDescuento.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirDescuento();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarDescuento();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarDescuento();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarDescuento(); MostrarDescuento();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgDescuento_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgDescuento.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgDescuento, e, dgDescuento.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgDescuento.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgDescuento, e, dgDescuento.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgDescuento.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgDescuento, e, dgDescuento.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgDescuento.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgDescuento, e, dgDescuento.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
