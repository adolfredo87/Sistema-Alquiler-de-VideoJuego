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
    public class Producto
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.String _nombre;
        private System.String _marca;
        private System.Int32 _idcategoriaProducto;
        private CategoriaProducto _categoriaProducto;
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
        public String Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public Int32 IDcategoriaProducto
        {
            get { return _idcategoriaProducto; }
            set { _idcategoriaProducto = value; }
        }
        public CategoriaProducto CategoriaProducto
        {
            get { return _categoriaProducto; }
            set { _categoriaProducto = value; }
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
