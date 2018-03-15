using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using LogicaNegocio;
using EntidadNegocio;
using Presentacion.Plantilla;

namespace Presentacion.Operaciones
{
    public partial class frmPago : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.AlquilerController _ctrlAlquiler = new LogicaNegocio.AlquilerController();
        private EntidadNegocio.Entidades.Alquiler _alquiler = new EntidadNegocio.Entidades.Alquiler();
        private List<EntidadNegocio.Entidades.Alquiler> _lstAlquiler = new List<EntidadNegocio.Entidades.Alquiler>();
        private LogicaNegocio.ClienteController _ctrlCliente = new LogicaNegocio.ClienteController();
        private List<EntidadNegocio.Entidades.Cliente> _lstClientes = new List<EntidadNegocio.Entidades.Cliente>();
        private LogicaNegocio.ProductoController _ctrlProducto = new LogicaNegocio.ProductoController();
        private List<EntidadNegocio.Entidades.Producto> _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
        private int _idCliente = 0;
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Alquiler _alquiler);
        public event GuardarEventHandler Guardar;
        #endregion

        #region "Eventos"
        internal delegate void MenuNuevoEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuNuevoEventHandler MenuNuevo;
        internal delegate void MenuBuscarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuBuscarEventHandler MenuBuscar;
        internal delegate void MenuModificarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuModificarEventHandler MenuModificar;
        internal delegate void MenuGuardarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuGuardarEventHandler MenuGuardar;
        internal delegate void MenuCancelarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuCancelarEventHandler MenuCancelar;
        internal delegate void MenuSalirEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuSalirEventHandler MenuSalir;
        #endregion

        public frmPago()
        {
            InitializeComponent();
            txtID.Enabled = false;
            cmbCliente.Enabled = false;
            dtpFecha.Enabled = false;
            txtDescuento.Enabled = false;
            cmbEstatus.Enabled = false;
            txtTotal.Enabled = false;
            gbDetalle.Enabled = false;
        }
        private void CargarClientes()
        {
            try
            {
                _lstClientes = _ctrlCliente.ObtenerItemsClinetePorPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboCliente()
        {
            this.CargarClientes();
            List<EntidadNegocio.Entidades.Cliente> _clientes = new List<EntidadNegocio.Entidades.Cliente>();
            _clientes = (from c in _lstClientes select c).ToList();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ID";
            cmbCliente.DataSource = _clientes;
        }
        private void ObtenerProductos()
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
        private void CargarProducto()
        {
            try
            {
                ObtenerProductos();
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgDetalle.Columns["colProducto"]);
                column.DisplayMember = "Descripcion";
                column.ValueMember = "ID";
                column.DataSource = (from cp in _lstProductos select cp).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarAlquilerPorPagar()
        {
            try
            {
                _lstAlquiler = _ctrlAlquiler.ObtenerItemsPorPagar(_idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarAlquilerPorPagar()
        {
            try
            {
                dgDetalle.AutoGenerateColumns = false;
                dgDetalle.DataSource = null;
                dgDetalle.DataSource = _lstAlquiler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarComboEstatus()
        {
            try
            {
                List<EntidadNegocio.Entidades.EstatusRegistro> l = new List<EntidadNegocio.Entidades.EstatusRegistro>();
                int[] values = ((int[])Enum.GetValues(typeof(EntidadNegocio.Enumerados.EnumEstatus.Registro)));
                EntidadNegocio.Entidades.EstatusRegistro i;
                foreach (int value in values)
                {
                    i = new EntidadNegocio.Entidades.EstatusRegistro();
                    i.Descripcion = Enum.GetName(typeof(EntidadNegocio.Enumerados.EnumTipos.TipoAccionAlquiler), value);
                    i.Estatus = value;
                    l.Add(i);
                }
                cmbEstatus.DataSource = l;
                cmbEstatus.DisplayMember = "Descripcion";
                cmbEstatus.ValueMember = "Estatus";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu Accion)
        {
            switch (Accion)
            {
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Nuevo:
                    mstpItemNuevo.Enabled = false;
                    mstpItemBuscar.Enabled = false;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = true;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar:
                    mstpItemNuevo.Enabled = false;
                    if (mstpItemBuscar.Tag != "N") mstpItemBuscar.Enabled = true;
                    if (mstpItemModificar.Tag != "N") mstpItemModificar.Enabled = true;
                    mstpItemGuardar.Enabled = false;
                    mstpItemCancelar.Enabled = true;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = false;
                    dtpFecha.Enabled = false;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = false;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Modificar:
                    mstpItemNuevo.Enabled = false;
                    mstpItemBuscar.Enabled = false;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = true;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Eliminar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Cancelar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Inicializar:
                    if (mstpItemNuevo.Tag != "N") mstpItemNuevo.Enabled = true;
                    if (mstpItemBuscar.Tag != "N") mstpItemBuscar.Enabled = true;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = false;
                    mstpItemCancelar.Enabled = false;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = false;
                    dtpFecha.Enabled = false;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = false;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
            }
        }
        public void TeclaPresionada(System.Windows.Forms.Keys Tecla)
        {
            switch (Tecla)
            {
                case System.Windows.Forms.Keys.F7:
                    if (MenuNuevo != null) MenuNuevo(mstpItemNuevo, null); ;
                    break;
                case System.Windows.Forms.Keys.F8:
                    if (MenuBuscar != null) MenuBuscar(mstpItemBuscar, null); ;
                    break;
                case System.Windows.Forms.Keys.F9:
                    if (MenuModificar != null) MenuModificar(mstpItemModificar, null); ;
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
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idCliente = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());
            CargarProducto(); CargarAlquilerPorPagar(); MostrarAlquilerPorPagar();
        }
        private void frmPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmPago_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Pago";
                this.Text = "Pago";
                this.CargarComboCliente();
                this.CargarProducto();
                this.LlenarComboEstatus();
                this.CargarAlquilerPorPagar();
                this.MostrarAlquilerPorPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
