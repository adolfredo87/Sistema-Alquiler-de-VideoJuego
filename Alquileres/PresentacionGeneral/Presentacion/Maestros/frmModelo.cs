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
    public partial class frmModelo : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.ModeloController _ctrlModelo = new LogicaNegocio.ModeloController();
        private EntidadNegocio.Entidades.Modelo _modelo = new EntidadNegocio.Entidades.Modelo();
        private List<EntidadNegocio.Entidades.Modelo> _lstModelo = new List<EntidadNegocio.Entidades.Modelo>();
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Modelo _modelo);
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

        public frmModelo()
        {
            InitializeComponent();
        }
        private void CargarModelo()
        {
            try
            {
                _lstModelo = _ctrlModelo.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarModelo()
        {
            try
            {
                dgModelo.AutoGenerateColumns = false;
                dgModelo.DataSource = null;
                dgModelo.DataSource = _lstModelo;
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
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgModelo.Columns["colEstatus"]);
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
        private void AñadirModelo()
        {
            try
            {
                EntidadNegocio.Entidades.Modelo _Modelo = new EntidadNegocio.Entidades.Modelo();
                _Modelo.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                _Modelo.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                if (_lstModelo.Count == 0) _lstModelo = new List<EntidadNegocio.Entidades.Modelo>();
                _lstModelo.Add(_Modelo);
                MostrarModelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarModelo()
        {
            try
            {
                if (_lstModelo.Count > 0)
                {
                    ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                    ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
                    if (((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar)
                    {
                        ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                    }
                    if (_lstModelo.Count != 0)
                    {
                        if (_ctrlModelo.DatosValidos(_lstModelo))
                        {
                            if (_ctrlModelo.Guardar(_lstModelo))
                            {
                                //Se elimina la Modelo del Producto
                            }
                        }
                    }
                    else
                    {
                        _lstModelo.Remove(((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem));
                    }
                }
                CargarModelo();
                MostrarModelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarModelo()
        {
            try
            {
                dgModelo.EndEdit();
                if (_ctrlModelo.Guardar(_lstModelo))
                {
                    CargarModelo();
                    MostrarModelo();
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgModelo.Focus();
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
        private void frmModelo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmModelo_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Modelo";
                this.Text = "Modelo";
                LlenarComboGridEstatus();
                CargarModelo();
                MostrarModelo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgModelo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgModelo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    if (_ctrlModelo.DatoDuplicado(_lstModelo, ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).ID))
                    {
                        MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_DatosRepetidos, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).ID = Int32.Parse(_ctrlModelo.UltimoID().ToString());
                    }
                }
                if (((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Edicion != EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    ((EntidadNegocio.Entidades.Modelo)dgModelo.CurrentRow.DataBoundItem).Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
                }
                dgModelo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemInsert_Click(object sender, EventArgs e)
        {
            AñadirModelo();
        }
        private void mstpItemSupr_Click(object sender, EventArgs e)
        {
            EliminarModelo();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            GuardarModelo();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            CargarModelo(); MostrarModelo();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmModelo_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void dgModelo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgModelo.CurrentCell.ColumnIndex == 0)
                {
                    FormatoCeldaGrid(dgModelo, e, dgModelo.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros);
                }
                if (dgModelo.CurrentCell.ColumnIndex == 1)
                {
                    FormatoCeldaGrid(dgModelo, e, dgModelo.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgModelo.CurrentCell.ColumnIndex == 2)
                {
                    FormatoCeldaGrid(dgModelo, e, dgModelo.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
                if (dgModelo.CurrentCell.ColumnIndex == 3)
                {
                    FormatoCeldaGrid(dgModelo, e, dgModelo.CurrentCell.ColumnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
