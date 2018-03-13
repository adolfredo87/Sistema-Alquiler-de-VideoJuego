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

namespace Presentacion.Maestros
{
    public partial class frmCliente : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.ClienteController _ctrlCliente;
        private EntidadNegocio.Entidades.Cliente _cliente;
        private int _idcliente;
        public delegate void GuardarEventHandler(EntidadNegocio.Entidades.Cliente _cliente);
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
        internal delegate void MenuEliminarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuEliminarEventHandler MenuEliminar;
        internal delegate void MenuCancelarEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuCancelarEventHandler MenuCancelar;
        internal delegate void MenuSalirEventHandler(System.Object sender, System.EventArgs e);
        internal event MenuSalirEventHandler MenuSalir;
        #endregion

        public frmCliente()
        {
            InitializeComponent();
            _ctrlCliente = new LogicaNegocio.ClienteController();
            _cliente = new EntidadNegocio.Entidades.Cliente();
        }
        public frmCliente(int idcliente)
        {
            InitializeComponent();
            _ctrlCliente = new LogicaNegocio.ClienteController();
            _cliente = new EntidadNegocio.Entidades.Cliente();
            _idcliente = idcliente;
            this.mstpItemCancelar.Visible = false;
            this.mstpItemEliminar.Visible = false;
            this.mstpItemModificar.Visible = false;
            this.mstpItemNuevo.Visible = false;
            txtCodigo.TabIndex = 0;
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
                    mstpItemEliminar.Enabled = false;
                    mstpItemCancelar.Enabled = true;
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtCorreo.Enabled = true;
                    txtDireccion.Enabled = true;
                    cmbEstatus.Enabled = true;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar:
                    mstpItemNuevo.Enabled = false;
                    if (mstpItemBuscar.Tag != "N") mstpItemBuscar.Enabled = true;
                    if (mstpItemModificar.Tag != "N") mstpItemModificar.Enabled = true;
                    mstpItemGuardar.Enabled = false;
                    if (mstpItemEliminar.Tag != "N") mstpItemEliminar.Enabled = true;
                    mstpItemCancelar.Enabled = true;
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtDireccion.Enabled = false;
                    cmbEstatus.Enabled = false;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Modificar:
                    mstpItemNuevo.Enabled = false;
                    mstpItemBuscar.Enabled = false;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = true;
                    mstpItemEliminar.Enabled = false;
                    mstpItemCancelar.Enabled = true;
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = true;
                    txtTelefono.Enabled = true;
                    txtCorreo.Enabled = true;
                    txtDireccion.Enabled = true;
                    cmbEstatus.Enabled = true;
                    break;
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Eliminar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Cancelar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar:
                case EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Inicializar:
                    if (mstpItemNuevo.Tag != "N") mstpItemNuevo.Enabled = true;
                    if (mstpItemBuscar.Tag != "N") mstpItemBuscar.Enabled = true;
                    mstpItemModificar.Enabled = false;
                    mstpItemGuardar.Enabled = false;
                    mstpItemEliminar.Enabled = false;
                    mstpItemCancelar.Enabled = false;
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtDireccion.Enabled = false;
                    cmbEstatus.Enabled = false;
                    break;
            }
        }
        public void TeclaPresionada(System.Windows.Forms.Keys Tecla)
        {
            switch (Tecla)
            {
                case System.Windows.Forms.Keys.F7:
                    if (MenuNuevo != null) MenuNuevo(mstpItemNuevo, null);;
                    break;
                case System.Windows.Forms.Keys.F8:
                    if (MenuBuscar != null) MenuBuscar(mstpItemBuscar, null);;
                    break;
                case System.Windows.Forms.Keys.F9:
                    if (MenuModificar != null) MenuModificar(mstpItemModificar, null);;
                    break;
                case System.Windows.Forms.Keys.F10:
                    if (MenuGuardar != null) MenuGuardar(mstpItemGuardar, null);;
                    break;
                case System.Windows.Forms.Keys.F11:
                    if (MenuEliminar != null) MenuEliminar(mstpItemEliminar, null);;
                    break;
                case System.Windows.Forms.Keys.F12:
                    if (MenuCancelar != null) MenuCancelar(mstpItemCancelar, null);;
                    break;
                case System.Windows.Forms.Keys.Escape:
                    if (MenuSalir != null) MenuSalir(mstpItemSalir, null);;
                    break;
            }
        }
        private void mstpItemNuevo_Click(object sender, EventArgs e)
        {
            this.NuevoCliente(); this.txtNombre.Focus();
        }
        private void mstpItemBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarClientes();
        }
        private void mstpItemModificar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            _cliente.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Editado;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Modificar);
            txtNombre.Focus();
        }
        private void mstpItemGuardar_Click(object sender, EventArgs e)
        {
            _cliente.ID = Convert.ToInt32(txtCodigo.Text.ToString());
            _cliente.Nombre = txtNombre.Text;
            _cliente.Telefono = txtTelefono.Text;
            _cliente.Correo = txtCorreo.Text;
            _cliente.Direccion = txtDireccion.Text;
            List<EntidadNegocio.Entidades.Cliente> _listC = new List<EntidadNegocio.Entidades.Cliente>();
            _listC.Add(_cliente);
            if (_ctrlCliente.Guardar(_listC))
            {
                MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Guardado, EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarCampos();
                this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Guardar);
                if (Guardar != null) Guardar(_cliente);;
            }
        }
        private void mstpItemEliminar_Click(object sender, EventArgs e)
        {
            _cliente.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Inactivo;
            _cliente.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Eliminar;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Eliminar);
            List<EntidadNegocio.Entidades.Cliente> _listC = new List<EntidadNegocio.Entidades.Cliente>();
            _listC.Add(_cliente);
            if (_ctrlCliente.Guardar(_listC))
            {
                MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Info_Eliminado, EntidadNegocio.Entidades.Mensajes.Titulo_Eliminar, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarCampos();
            }
            this.Cancelar();
        }
        private void mstpItemCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }
        private void mstpItemSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.GrupBox.Text = "Cleinte"; this.Text = "Cleinte";
            this.LlenarComboEstatus();
        }
        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(EntidadNegocio.Entidades.Mensajes.Salir, EntidadNegocio.Entidades.Mensajes.Titulo_Salir, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            this.TeclaPresionada(e.KeyCode);
        }
        private void NuevoCliente()
        {
            this.LimpiarCampos();
            int id = Convert.ToInt32(_ctrlCliente.UltimoID());
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
            _cliente.Status = EntidadNegocio.Enumerados.EnumEstatus.Registro.Activo;
            this.cmbEstatus.Text = _cliente.Status.ToString();
            _cliente.Edicion = EntidadNegocio.Enumerados.EnumEstatus.Edicion.Nuevo;
            this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Nuevo);
            txtNombre.Focus();
        }
        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cmbEstatus.Text = "";
        }
        private void MostrarDatos()
        {
            try
            {
                txtCodigo.Text = Convert.ToString(_cliente.ID.ToString());
                txtNombre.Text = _cliente.Nombre;
                txtTelefono.Text = _cliente.Telefono;
                txtCorreo.Text = _cliente.Correo;
                txtDireccion.Text = _cliente.Direccion;
                cmbEstatus.Text = _cliente.Status.ToString();
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
        private void BuscarClientes()
        {
            try
            {
                int result = 0;
                string caturar = Interaction.InputBox("Ingresa el codigo del Cliente", EntidadNegocio.Entidades.Mensajes.Titulo_Guardar, "1");
                if (String.IsNullOrEmpty(caturar))
                {
                    MessageBox.Show("Introduzca un valor numerico", EntidadNegocio.Entidades.Mensajes.Titulo_Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cancelar();
                }
                else if (Int32.TryParse(caturar, out result))
                {
                    _cliente = new EntidadNegocio.Entidades.Cliente();
                    _cliente = _ctrlCliente.Details(result);
                    LimpiarCampos(); LlenarComboEstatus(); MostrarDatos(); 
                    this.ControlBotonesMenu(EntidadNegocio.Enumerados.EnumTipos.AccionMenu.Buscar);
                }
                else
                {
                    MessageBox.Show("El valor no es numerico, introduzca un valor numerico", EntidadNegocio.Entidades.Mensajes.Titulo_Advertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Cancelar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
