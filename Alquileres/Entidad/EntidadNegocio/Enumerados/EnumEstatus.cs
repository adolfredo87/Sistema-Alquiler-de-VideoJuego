using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;

namespace EntidadNegocio.Enumerados
{
    public class EnumEstatus
    {
        public enum Registro
        {
            Inactivo = 0,
            Activo = 1
        }

        public enum Edicion
        {
            Normal = 0,
            Nuevo = 1,
            Editado = 2,
            Eliminar = 3
        }
    }
}

// Soli Deo Gloria