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
    public class Modelo
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.String _codigo;
        private System.String _descripcion;
        private EnumEstatus.Registro _estatus = EnumEstatus.Registro.Activo;
        private System.Int32 _idTipo;
        private Tipo _tipo;
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
        public EnumEstatus.Registro Status
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public System.Int32 IDTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        public Tipo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public EnumEstatus.Edicion Edicion
        {
            get { return _edicion; }
            set { _edicion = value; }
        }
        #endregion
    }
}
