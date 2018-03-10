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
    public class EstatusRegistro
    {
        #region "Atributos"
        private System.Int32 _id;
        private System.String _descripcion;
        #endregion

        #region "Propiedades"
        public System.Int32 Estatus
        {
            get { return _id; }
            set { _id = value; }
        }
        public String Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        #endregion
    }
}