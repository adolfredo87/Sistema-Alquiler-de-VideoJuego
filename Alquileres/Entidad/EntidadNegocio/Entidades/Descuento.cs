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
    public class Descuento
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.String _codigo;
        private System.String _descripcion;
        private System.Double _porcentajeDescuento = 0;
        private EnumEstatus.Registro _estatus;
        private EnumEstatus.Registro _status = EnumEstatus.Registro.Activo;
        private EnumEstatus.Edicion _edicion = EnumEstatus.Edicion.Normal;
        #endregion

        #region "Propiedades"
        public Int32 ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public System.String Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public Double PorcentajeDescuento
        {
            get { return _porcentajeDescuento; }
            set { _porcentajeDescuento = value; }
        }
        public EnumEstatus.Registro Estatus
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
