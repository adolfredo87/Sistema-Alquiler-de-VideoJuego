﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Principal
{
    public partial class frmVentanaPrincipal : Form
    {
        public frmVentanaPrincipal()
        {
            InitializeComponent();
        }
        private Boolean FormularioEstaCargado(string NombreFormulario)
        {
            bool respuesta = false;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].GetType().UnderlyingSystemType.FullName == NombreFormulario)
                {
                    this.MdiChildren[i].BringToFront();
                    respuesta = true;
                    break;
                }
            }
            return respuesta;
        }
        private void Salir_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmVentanaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            GC.Collect();
            Application.Exit();
        }
        private void frmVentanaPrincipal_Load(object sender, EventArgs e)
        {
            string titulo = "Sistema de Alquiler VideoGames";
            this.Text = titulo;
        }
        private void Refrescar_ToolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void Cliente_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmCliente"))
                {
                    Presentacion.Maestros.frmCliente frmMdiParent = new Presentacion.Maestros.frmCliente();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cliente_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmCliente"))
                {
                    Presentacion.Maestros.frmCliente frmMdiParent = new Presentacion.Maestros.frmCliente();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Producto_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmProducto"))
                {
                    Presentacion.Maestros.frmProducto frmMdiParent = new Presentacion.Maestros.frmProducto();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Producto_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmProducto"))
                {
                    Presentacion.Maestros.frmProducto frmMdiParent = new Presentacion.Maestros.frmProducto();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Marca_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmMarca"))
                {
                    Presentacion.Maestros.frmMarca frmMdiParent = new Presentacion.Maestros.frmMarca();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Marca_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmMarca"))
                {
                    Presentacion.Maestros.frmMarca frmMdiParent = new Presentacion.Maestros.frmMarca();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Modelo_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmModelo"))
                {
                    Presentacion.Maestros.frmModelo frmMdiParent = new Presentacion.Maestros.frmModelo();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Modelo_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmModelo"))
                {
                    Presentacion.Maestros.frmModelo frmMdiParent = new Presentacion.Maestros.frmModelo();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Categoria_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmCategoria"))
                {
                    Presentacion.Maestros.frmCategoria frmMdiParent = new Presentacion.Maestros.frmCategoria();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Categoria_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmCategoria"))
                {
                    Presentacion.Maestros.frmCategoria frmMdiParent = new Presentacion.Maestros.frmCategoria();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Descuento_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmDescuento"))
                {
                    Presentacion.Maestros.frmDescuento frmMdiParent = new Presentacion.Maestros.frmDescuento();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Descuento_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmDescuento"))
                {
                    Presentacion.Maestros.frmDescuento frmMdiParent = new Presentacion.Maestros.frmDescuento();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Precio_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmPrecio"))
                {
                    Presentacion.Maestros.frmPrecio frmMdiParent = new Presentacion.Maestros.frmPrecio();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Precio_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Maestros.frmPrecio"))
                {
                    Presentacion.Maestros.frmPrecio frmMdiParent = new Presentacion.Maestros.frmPrecio();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Alquiler_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Operaciones.frmAlquiler"))
                {
                    Presentacion.Operaciones.frmAlquiler frmMdiParent = new Presentacion.Operaciones.frmAlquiler();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Alquiler_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Operaciones.frmAlquiler"))
                {
                    Presentacion.Operaciones.frmAlquiler frmMdiParent = new Presentacion.Operaciones.frmAlquiler();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Pago_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Operaciones.frmPago"))
                {
                    Presentacion.Operaciones.frmPago frmMdiParent = new Presentacion.Operaciones.frmPago();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Pago_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Operaciones.frmPago"))
                {
                    Presentacion.Operaciones.frmPago frmMdiParent = new Presentacion.Operaciones.frmPago();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Busqueda_ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormularioEstaCargado("Presentacion.Consultas.frmAlquilerPorPagar"))
                {
                    Presentacion.Consultas.frmAlquilerPorPagar frmMdiParent = new Presentacion.Consultas.frmAlquilerPorPagar();
                    frmMdiParent.MdiParent = this;
                    frmMdiParent.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, EntidadNegocio.Entidades.Mensajes.Titulo_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Calculadora_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void TemasAyuda_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void AcercaSistema_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
