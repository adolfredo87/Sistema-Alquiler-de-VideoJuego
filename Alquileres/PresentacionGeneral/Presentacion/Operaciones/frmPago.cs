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
        private List<EntidadNegocio.Entidades.Alquiler> _lstAlquiler = new List<EntidadNegocio.Entidades.Alquiler>();
        private LogicaNegocio.ClienteController _ctrlCliente = new LogicaNegocio.ClienteController();
        private EntidadNegocio.Entidades.Cliente _cliente = new EntidadNegocio.Entidades.Cliente();
        private List<EntidadNegocio.Entidades.Cliente> _lstClientes = new List<EntidadNegocio.Entidades.Cliente>();
        private LogicaNegocio.PagoCabeceraController _ctrlPago = new LogicaNegocio.PagoCabeceraController();
        private EntidadNegocio.Entidades.PagoCabecera _pago = new EntidadNegocio.Entidades.PagoCabecera();
        private LogicaNegocio.ProductoController _ctrlProducto = new LogicaNegocio.ProductoController();
        private List<EntidadNegocio.Entidades.Producto> _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
        private int _idCliente = 0;
        private int _idPagoCab = 0;
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.PagoCabecera _pago);
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
            List<EntidadNegocio.Entidades.Cliente> _clientes = null; 
            _clientes = new List<EntidadNegocio.Entidades.Cliente>();
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
                List<EntidadNegocio.Entidades.Producto> _productos = new List<EntidadNegocio.Entidades.Producto>();
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgDetalle.Columns["colProducto"]);
                _productos = (from cp in _lstProductos select cp).ToList();
                column.DisplayMember = "Descripcion";
                column.ValueMember = "ID";
                column.DataSource = _productos;
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
                    i.Descripcion = Enum.GetName(typeof(EntidadNegocio.Enumerados.EnumEstatus.Registro), value);
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
                    mstpItemGuardar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = false;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar:
                    mstpItemNuevo.Enabled = false;
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
                    mstpItemGuardar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtID.Enabled = false;
                    cmbCliente.Enabled = true;
                    dtpFecha.Enabled = true;
                    txtDescuento.Enabled = false;
                    cmbEstatus.Enabled = false;
                    txtTotal.Enabled = false;
                    gbDetalle.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Eliminar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Cancelar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Inicializar:
                    if (mstpItemNuevo.Tag != "N") mstpItemNuevo.Enabled = true;
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
            this.MostrarDatos();
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
                this.LimpiarCampos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            this.lblTotal.Text = this.txtTotal.Text;
        }
        private void mstpItemNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoPago();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _pago.ID = Convert.ToInt32(txtID.Text.ToString());
                _pago.IDCliente = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());
                _pago.Fecha = DateTime.Parse(this.dtpFecha.Value.ToLongDateString());
                _pago.MontoTotal = Double.Parse(this.txtTotal.Text.ToString());
                if (cmbEstatus.SelectedValue.ToString() == "1")
                {
                    _pago.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
                }
                else
                {
                    _pago.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
                }
                List<EntidadNegocio.Entidades.PagoCabecera> _listP = new List<EntidadNegocio.Entidades.PagoCabecera>();
                _listP.Add(_pago);
                if (_ctrlPago.Guardar(_listP))
                {
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarCampos();
                    this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar);
                    if (Guardar != null) Guardar(_pago); ;
                    this.LimpiarCampos(); this.Cancelar(); this.CargarDatos();
                    _ctrlPago = new LogicaNegocio.PagoCabeceraController();
                    _pago = new EntidadNegocio.Entidades.PagoCabecera();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarDatos()
        {
            this.LimpiarCampos();
            this.CargarComboCliente();
            this.CargarProducto();
            this.LlenarComboEstatus();
            this.CargarAlquilerPorPagar();
            this.MostrarAlquilerPorPagar();
        }
        private void NuevoPago()
        {
            this.LimpiarCampos();
            this.CargarDatos(); this.MostrarDatos();
            _idPagoCab = Convert.ToInt32(_ctrlPago.UltimoID());
            if (_idPagoCab == 0)
            {
                _idPagoCab = _idPagoCab + 1;
            }
            else
            {
                _idPagoCab = _idPagoCab + 1;
            }
            _pago.ID = _idPagoCab;
            this.txtID.Text = _pago.ID.ToString();
            this.cmbEstatus.Text = _pago.Status.ToString();
            _pago.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Nuevo);
        }
        private void LimpiarCampos()
        {
            this.txtID.Text = "";
            this.cmbCliente.Text = "";
            this.dtpFecha.Value = DateTime.Now;
            this.lblRows.Text = "DataGrid - Rows: 0";
            this.txtDescuento.Text = "0.0";
            this.txtTotal.Text = "0.0";
            this.cmbEstatus.Text = "";
        }
        private void MostrarDatos()
        {
            try
            {
                this.txtID.Text = Convert.ToString(_idPagoCab.ToString());
                _cliente = _ctrlCliente.DetailsClinetePorPagar(_idCliente);
                if (_pago.Edicion == EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo)
                {
                    _pago = _ctrlPago.Details(_idCliente);
                    _pago.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
                }
                else
                {
                    _pago = _ctrlPago.Details(_idCliente);
                }
                this.cmbCliente.Text = _cliente.Nombre;
                this.dtpFecha.Value = _pago.Fecha;
                this.lblRows.Text = "DataGrid - Rows: " + _cliente.NumAlquileres.ToString();
                this.txtDescuento.Text = _pago.Descuento.ToString();
                this.txtTotal.Text = _pago.MontoTotal.ToString();
                this.lblMontoExento.Text = _pago.MontoExento.ToString();
                this.cmbEstatus.Text = _pago.Status.ToString();
                CargarProducto(); CargarAlquilerPorPagar(); MostrarAlquilerPorPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cancelar()
        {
            this.LimpiarCampos();
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Cancelar);
        }
        
    }
}
