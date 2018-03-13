using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(Cliente.MetaData))]
    [DisplayName("Clientes")]
    public partial class Cliente
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Cliente"), StringLength(50)]
            public Int32 ID { get; set; }

            [Required, DisplayName("Nombre del Cliente"), StringLength(200)]
            public String Nombre { get; set; }

            [Required, DisplayName("Telefono del Cliente"), StringLength(200)]
            public String Telefono { get; set; }

            [DisplayName("Correo del Cliente"), StringLength(200)]
            public String Correo { get; set; }

            [DisplayName("Direccion del Cliente"), StringLength(200)]
            public String Direccion { get; set; }

            [Required, DisplayName("Estatus")]
            public int Estatus { get; set; }

        }

        #region Metodos Extendidos del Entities Framework
        #endregion
    }
}