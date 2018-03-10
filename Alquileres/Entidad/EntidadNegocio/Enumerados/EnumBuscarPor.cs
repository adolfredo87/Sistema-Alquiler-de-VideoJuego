using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadNegocio.Enumerados
{
    public class EnumBuscarPor
    {
        enum Estatus
        {
            Inactivo = 1,
            Activo = 2
        }

        enum Cliente
        {
            ID = 1,
            Nombre = 2
        }

        enum Categoria
        {
            Id = 1,
            Descripcion = 2
        }

        enum Venta
        {
            Id = 1
        }
    }
}
