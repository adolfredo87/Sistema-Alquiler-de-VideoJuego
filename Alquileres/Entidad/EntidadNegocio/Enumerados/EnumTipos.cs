using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace EntidadNegocio.Enumerados
{
    public class EnumTipos
    {
        public enum TipoLocalidad
        {
            Estado = 1,
            Municipio = 2,
            Ciudad = 3
        }

        public enum TipoAccion
        {
            Carga = 1,
            Descarga = 2,
            Devolucion = 3
        }

        public enum TipoFormato
        {
            Numeros = 1,
            Decimales = 2,
            Letras = 3,
            NumeroLetras = 4
        }

        public enum AccionMenu
        {
            Inicializar = 0,
            Nuevo = 1,
            Buscar = 2,
            Modificar = 3,
            Guardar = 4,
            Eliminar = 5,
            Cancelar = 6
        }
    }
}

// Soli Deo Gloria