using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Presentacion.Plantilla
{
    public partial class FrmPlantilla : Form
    {
        #region "Atributos"
        private int _columnIndex = 0;
        private System.Windows.Forms.DataGridView _grid;
        private EntidadNegocio.Enumerados.EnumTipos.TipoFormato _caracter;
        #endregion

        public FrmPlantilla()
        {
            InitializeComponent();
        }
        public void FormatoNumeroEntero(System.Windows.Forms.KeyPressEventArgs e, TextBox Text)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void FormatoLetra(System.Windows.Forms.KeyPressEventArgs e, TextBox Text)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public void FormatoNumeroLetra(System.Windows.Forms.KeyPressEventArgs e, TextBox Text)
        {
            if (Char.IsLetter(e.KeyChar) | Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void KeypessCeldaEnGrid(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (_columnIndex == _grid.CurrentCell.ColumnIndex)
            {
                switch (_caracter)
                {
                    case EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Numeros:
                        FormatoNumeroEntero(e, ((TextBox)sender));
                        break;
                    case EntidadNegocio.Enumerados.EnumTipos.TipoFormato.Letras:
                        FormatoLetra(e, ((TextBox)sender));
                        break;
                    case EntidadNegocio.Enumerados.EnumTipos.TipoFormato.NumeroLetras:
                        FormatoNumeroLetra(e, ((TextBox)sender));
                        break;
                }
            }
        }
        public void FormatoCeldaGrid(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e, int columnIndex, EntidadNegocio.Enumerados.EnumTipos.TipoFormato caracter)
        {
            try
            {
                DataGridView _dataGridView = sender as DataGridView;
                if (_dataGridView.Name == "DataGridView")
                {
                    _grid = ((DataGridView)sender);
                    _columnIndex = columnIndex;
                    _caracter = caracter;
                    TextBox validar = ((TextBox)e.Control);
                    validar.KeyPress += new KeyPressEventHandler(KeypessCeldaEnGrid);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

// Soli Deo Gloria