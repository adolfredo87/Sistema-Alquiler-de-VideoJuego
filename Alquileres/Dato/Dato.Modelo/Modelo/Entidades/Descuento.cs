using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(Descuento.MetaData))]
    [DisplayName("Descuentos")]
    public partial class Descuento
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID"), StringLength(50)]
            public int ID { get; set; }

            [Required, DisplayName("Codigo del Descuento"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Descripcion del Descuento"), StringLength(100)]
            public String Descripcion { get; set; }

            [Required, DisplayName("Porcentaje del Descuento")]
            public Double PorcentajeDescuento { get; set; }

            [Required, DisplayName("Estatus")]
            public int Estatus { get; set; }
        }

        #region Metodos Extendidos del Entities Framework
        #endregion
    }
}