using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Consultas
{
    public partial class frmAlquilerPorPagar : Presentacion.Plantilla.FrmPlantilla
    {
        #region "Atributos"
        private LogicaNegocio.AlquilerController _ctrlAlquiler = new LogicaNegocio.AlquilerController();
        private List<EntidadNegocio.Entidades.Alquiler> _lstAlquiler = new List<EntidadNegocio.Entidades.Alquiler>();
        private LogicaNegocio.ClienteController _ctrlCliente = new LogicaNegocio.ClienteController();
        private List<EntidadNegocio.Entidades.Cliente> _lstClientes = new List<EntidadNegocio.Entidades.Cliente>();
        private LogicaNegocio.ProductoController _ctrlProducto = new LogicaNegocio.ProductoController();
        private List<EntidadNegocio.Entidades.Producto> _lstProductos = new List<EntidadNegocio.Entidades.Producto>();
        private int _idCliente = 0;
        #endregion

        public frmAlquilerPorPagar()
        {
            InitializeComponent();
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
                DataGridViewComboBoxColumn column = ((DataGridViewComboBoxColumn)dgAlquiler.Columns["colProducto"]);
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
                dgAlquiler.AutoGenerateColumns = false;
                dgAlquiler.DataSource = null;
                dgAlquiler.DataSource = _lstAlquiler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAlquilerPorPagar_Load(object sender, EventArgs e)
        {
            try
            {
                this.GrupBox.Text = "Alquiler Por Pagar";
                this.Text = "Alquiler Por Pagar";
                this.CargarComboCliente();
                this.CargarProducto();
                this.CargarAlquilerPorPagar();
                this.MostrarAlquilerPorPagar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idCliente = Convert.ToInt32(this.cmbCliente.SelectedValue.ToString());
            CargarProducto(); CargarAlquilerPorPagar(); MostrarAlquilerPorPagar();
        }
    }
}
