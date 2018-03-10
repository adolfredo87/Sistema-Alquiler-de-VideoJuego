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
    public partial class frmAlquiler : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.AlquilerController _ctrlAlquiler = new LogicaNegocio.AlquilerController();
        private EntidadNegocio.Entidades.Alquiler _alquiler = new EntidadNegocio.Entidades.Alquiler();
        private LogicaNegocio.ClienteController _ctrlCliente = new LogicaNegocio.ClienteController();
        private List<EntidadNegocio.Entidades.Cliente> _lstClientes = new List<EntidadNegocio.Entidades.Cliente>();
        private LogicaNegocio.ProductoController _ctrlProducto = new LogicaNegocio.ProductoController();
        private List<EntidadNegocio.Entidades.Producto> _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
        private int _idalquiler;
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

        public frmAlquiler()
        {
            InitializeComponent();
            _ctrlAlquiler = new LogicaNegocio.AlquilerController();
            _alquiler = new EntidadNegocio.Entidades.Alquiler();
        }
        public frmAlquiler(int idalquiler)
        {
            InitializeComponent();
            _ctrlAlquiler = new LogicaNegocio.AlquilerController();
            _alquiler = new EntidadNegocio.Entidades.Alquiler();
            _idalquiler = idalquiler;
            this.mstpItemCancelar.Visible = false;
            this.mstpItemModificar.Visible = false;
            this.mstpItemNuevo.Visible = false;
            txtCodigo.TabIndex = 0;
        }
        private void CargarClientes()
        {
            try
            {
                _lstClientes = _ctrlCliente.ObtenerItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    txtCodigo.Enabled = false;
                    cmbCliente.Enabled = true;
                    cmbProducto.Enabled = true;
                    txtDesde.Enabled = true;
                    txtHasta.Enabled = true;
                    txtHora.Enabled = false;
                    txtDia.Enabled = false;
                    txtSemana.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtEstatus.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar:
                    mstpItemNuevo.Enabled = false;
                    if (mstpItemBuscar.Tag != "N") mstpItemBuscar.Enabled = true;
                    if (mstpItemModificar.Tag != "N") mstpItemModificar.Enabled = true;
                    mstpItemGuardar.Enabled = false;
                    mstpItemCancelar.Enabled = true;
                    txtCodigo.Enabled = false;
                    cmbCliente.Enabled = false;
                    cmbProducto.Enabled = false;
                    txtDesde.Enabled = false;
                    txtHasta.Enabled = false;
                    txtHora.Enabled = false;
                    txtDia.Enabled = false;
                    txtSemana.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtEstatus.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Modificar:
                    mstpItemNuevo.Enabled = false;
                    mstpItemBuscar.Enabled = false;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtCodigo.Enabled = false;
                    cmbCliente.Enabled = true;
                    cmbProducto.Enabled = true;
                    txtDesde.Enabled = true;
                    txtHasta.Enabled = true;
                    txtHora.Enabled = false;
                    txtDia.Enabled = false;
                    txtSemana.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtEstatus.Enabled = false;
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
                    txtCodigo.Enabled = false;
                    cmbCliente.Enabled = false;
                    cmbProducto.Enabled = false;
                    txtDesde.Enabled = false;
                    txtHasta.Enabled = false;
                    txtHora.Enabled = false;
                    txtDia.Enabled = false;
                    txtSemana.Enabled = false;
                    txtPrecio.Enabled = false;
                    txtEstatus.Enabled = false;
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
        private void mstpItemNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoAlquiler(); this.txtDesde.Focus();
        }
        private void mstpItemBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarAlquileres();
        }
        private void mstpItemModificar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            _alquiler.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Modificar);
            txtDesde.Focus();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                _alquiler.ID = Convert.ToInt32(txtCodigo.Text.ToString());
                _alquiler.IDCliente = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());
                _alquiler.IDProducto = Convert.ToInt32(this.cmbProducto.SelectedValue.ToString());
                _alquiler.FechaDesde = DateTime.Parse(txtDesde.Text.ToString());
                _alquiler.FechaHasta = DateTime.Parse(txtHasta.Text.ToString());
                List<EntidadNegocio.Entidades.Alquiler> _listA = new List<EntidadNegocio.Entidades.Alquiler>();
                _listA.Add(_alquiler);
                if (_ctrlAlquiler.Guardar(_listA))
                {
                    MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarCampos();
                    this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar);
                    if (Guardar != null) Guardar(_alquiler); ;
                    this.LimpiarCampos(); _ctrlAlquiler = new LogicaNegocio.AlquilerController();
                    _alquiler = new EntidadNegocio.Entidades.Alquiler();
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
        private void frmAlquiler_Load(object sender, EventArgs e)
        {
            this.GrupBox.Text = "Alquiler"; this.Text = "Alquiler";
        }
        private void frmAlquiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmAlquiler_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void NuevoAlquiler()
        {
            this.LimpiarCampos();
            int id = Convert.ToInt32(_ctrlAlquiler.UltimoID());
            if (id == 0)
            {
                id = id + 1;
            }
            else
            {
                id = id + 1;
            }
            txtCodigo.Text = id.ToString();
            txtCodigo.Enabled = false;
            this.CargarComboCliente();
            this.CargarComboProducto();
            this.txtDesde.Text = DateTime.Now.ToString();
            this.txtHasta.Text = DateTime.Now.ToString();
            _alquiler.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Nuevo);
            this.txtDesde.Focus();
        }
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            cmbCliente.Text = "";
            cmbProducto.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            txtHora.Text = "";
            txtDia.Text = "";
            txtSemana.Text = "";
            txtPrecio.Text = "";
            txtEstatus.Text = "";
        }
        private void MostrarDatos()
        {
            try
            {
                txtCodigo.Text = Convert.ToString(_alquiler.ID.ToString());
                cmbCliente.Text = _alquiler.Cliente.Nombre;
                cmbProducto.Text = _alquiler.Producto.Nombre;
                txtDesde.Text = _alquiler.FechaDesde.ToString();
                txtHasta.Text = _alquiler.FechaHasta.ToString();
                txtHora.Text = _alquiler.TiempoHora;
                txtDia.Text = _alquiler.TiempoDia;
                txtSemana.Text = _alquiler.TiempoSemana;
                txtPrecio.Text = _alquiler.PrecioEstimado.ToString();
                txtEstatus.Text = _alquiler.Estatus.ToString();
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
        private void BuscarAlquileres()
        {
            try
            {
                Int32 result = 0;
                String caturar = Interaction.InputBox("Ingresa el codigo del Alquiler", EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, "1");
                if (String.IsNullOrEmpty(caturar))
                {
                    MessageBox.Show("Introduzca un valor numerico", EntidadNegocio.Entidades.Mensajes.Titulo_Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Int32.TryParse(caturar, out result))
                {
                    _alquiler = new EntidadNegocio.Entidades.Alquiler();
                    _alquiler = _ctrlAlquiler.Details(result);
                    if (_alquiler.Estatus == 2)
                    {
                        MessageBox.Show("El alquiler solicitado ya se encuntra pago.", EntidadNegocio.Entidades.Mensajes.Titulo_Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Cancelar();
                    }
                    else
                    {
                        LimpiarCampos(); MostrarDatos();
                        this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar);
                    }
                }
                else
                {
                    MessageBox.Show("El valor no es numerico, introduzca un valor numerico", EntidadNegocio.Entidades.Mensajes.Titulo_Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void CargarComboProducto()
        {
            this.CargarProductos();
            List<EntidadNegocio.Entidades.Producto> _productos = new List<EntidadNegocio.Entidades.Producto>();
            _productos = (from c in _lstProductos select c).ToList();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ID";
            cmbProducto.DataSource = _productos;
        }
    }
}
