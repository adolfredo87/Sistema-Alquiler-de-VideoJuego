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
    public class Alquiler
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.Int32 _idCliente;
        private Cliente _cliente;
        private System.Int32 _idProducto;
        private Producto _producto;
        private System.DateTime _fechaDesde;
        private System.DateTime _fechaHasta;
        private System.String _timeHora;
        private System.String _timeDia;
        private System.String _timeSemana;
        private System.Double _precioEstimado = 0;
        private EnumTipos.TipoAccionAlquiler _estatus = EnumTipos.TipoAccionAlquiler.Procesado;
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
        public System.Int32 IDProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }
        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        public System.DateTime FechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }
        public System.DateTime FechaHasta
        {
            get { return _fechaHasta; }
            set { _fechaHasta = value; }
        }
        public System.String TiempoHora
        {
            get { return _timeHora; }
            set { _timeHora = value; }
        }
        public System.String TiempoDia
        {
            get { return _timeDia; }
            set { _timeDia = value; }
        }
        public System.String TiempoSemana
        {
            get { return _timeSemana; }
            set { _timeSemana = value; }
        }
        public Double PrecioEstimado
        {
            get { return _precioEstimado; }
            set { _precioEstimado = value; }
        }
        public EnumTipos.TipoAccionAlquiler Estatus
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
