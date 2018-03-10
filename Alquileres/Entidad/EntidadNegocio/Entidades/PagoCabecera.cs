using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using EntidadNegocio.Enumerados;

namespace EntidadNegocio.Entidades
{
    public class PagoCabecera
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.Int32 _idCliente;
        private Cliente _cliente;
        private System.DateTime _fecha;
        private System.Double _montoExc = 0;
        private System.Double _descuento = 0;
        private System.Double _montoTotal = 0;
        private System.Int32 _estatus = 1;
        private EnumEstatus.Registro _status = EnumEstatus.Registro.Activo;
        private EnumEstatus.Edicion _edicion = EnumEstatus.Edicion.Normal;
        #endregion

        #region "Propiedades"
        public Int32 ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public System.Int32 IDCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public System.DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public Double MontoExento
        {
            get { return _montoExc; }
            set { _montoExc = value; }
        }
        public Double Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        public Double MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        public Int32 Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public EnumEstatus.Registro Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public EnumEstatus.Edicion Edicion
        {
            get { return _edicion; }
            set { _edicion = value; }
        }
        #endregion
    }
}
