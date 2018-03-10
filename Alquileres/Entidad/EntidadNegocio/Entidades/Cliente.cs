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
    public class Cliente
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.String _nombre;
        private System.String _telefono;
        private System.String _correo;
        private System.String _direccion;
        private EnumEstatus.Registro _estatus = EnumEstatus.Registro.Activo;
        private EnumEstatus.Edicion _edicion = EnumEstatus.Edicion.Normal;
        #endregion

        #region "Propiedades"
        public Int32 ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public System.String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }
        public String Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public EnumEstatus.Registro Status
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        public EnumEstatus.Edicion Edicion
        {
            get { return _edicion; }
            set { _edicion = value; }
        }
        #endregion
    }
}
