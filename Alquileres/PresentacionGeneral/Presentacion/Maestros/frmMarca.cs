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
    public partial class frmMarca : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.MarcaController _ctrlMarca = new LogicaNegocio.MarcaController();
        private EntidadNegocio.Entidades.Marca _marca = new EntidadNegocio.Entidades.Marca();
        private List<EntidadNegocio.Entidades.Marca> _lstMarca = new List<EntidadNegocio.Entidades.Marca>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Marca _marca);
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

        public frmMarca()
        {
            InitializeComponent();
        }
        private void CargarMarca()
        {
            try
            {
                _lstMarca = _ctrlMarca.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarMarca()
        {
            try
            {
                dgMarca.AutoGenerateColumns = false;
                dgMarca.DataSource = null;
                dgMarca.DataSource = _lstMarca;
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
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgMarca.Columns["colEstatus"]);
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
        private void AñadirMarca()
        {
            try
            {
                EntidadNegocio.Entidades.Marca _Marca = new EntidadNegocio.Entidades.Marca();
                _Marca.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Marca.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstMarca.Count == 0) _lstMarca = new List<EntidadNegocio.Entidades.Marca>();
                _lstMarca.Add(_Marca);
                MostrarMarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarMarca()
        {
            try
            {
                if (_lstMarca.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstMarca.Count != 0)
                    {
                        if (_ctrlMarca.DatosValidos(_lstMarca))
                        {
                            if (_ctrlMarca.Guardar(_lstMarca))
                            {
                                //Se elimina la Marca del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstMarca.Remove(((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem));
                    }
                }
                CargarMarca();
                MostrarMarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarMarca()
        {
            try
            {
                dgMarca.EndEdit();
                if (_ctrlMarca.Guardar(_lstMarca))
                {
                    CargarMarca();
                    MostrarMarca();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgMarca.Focus();
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
        private void frmMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmMarca_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Marca";
                this.Text = "Marca";
                LlenarComboGridEstatus();
                CargarMarca();
                MostrarMarca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgMarca_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgMarca_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlMarca.DatoDuplicado(_lstMarca, ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlMarca.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Marca)dgMarca.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgMarca.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirMarca();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarMarca();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarMarca();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarMarca(); MostrarMarca();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmMarca_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgMarca_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgMarca.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgMarca, e, dgMarca.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgMarca.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgMarca, e, dgMarca.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgMarca.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgMarca, e, dgMarca.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgMarca.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgMarca, e, dgMarca.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
