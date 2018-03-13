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
        private System.Int32 _idTipo;
        private Tipo _tipo;
        private System.String _codigo;
        private System.String _descripcion;
        private System.Int32 _idmarca;
        private Marca _marca;
        private System.Int32 _idmodelo;
        private Modelo _modelo;
        private System.Int32 _idcategoria;
        private Categoria _categoria;
        private EnumEstatus.Registro _estatus = EnumEstatus.Registro.Activo;
        private EnumEstatus.Edicion _edicion = EnumEstatus.Edicion.Normal;
        #endregion

        #region "Propiedades"
        public Int32 ID
        {
            get { return _id; }
            set { _id = value; }
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
        public System.String Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public System.String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public Int32 IDMarca
        {
            get { return _idmarca; }
            set { _idmarca = value; }
        }
        public Marca Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public Int32 IDModelo
        {
            get { return _idmodelo; }
            set { _idmodelo = value; }
        }
        public Modelo Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public Int32 IDCategoria
        {
            get { return _idcategoria; }
            set { _idcategoria = value; }
        }
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
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
