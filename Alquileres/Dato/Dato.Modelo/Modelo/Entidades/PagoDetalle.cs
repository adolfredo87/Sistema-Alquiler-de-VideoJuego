﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(PagoDetalle.MetaData))]
    [DisplayName("Pago Detalle")]
    public partial class PagoDetalle
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Pago Detalle"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Pago Cabecera")]
            public PagoCabecera PagoCabecera { get; set; }

            [Required, DisplayName("Alquiler")]
            public Alquiler Alquiler { get; set; }

            [Required, DisplayName("Precio Unitario")]
            public Double PrecioUnitario { get; set; }

            [Required, DisplayName("Descuento")]
            public Double Descuento { get; set; }

            [Required, DisplayName("Precio Total")]
            public Double PrecioTotal { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public PagoCabecera PagoCabeceraLoad()
        {
            return Utility.Entity<PagoCabecera>.LoadReference(this.PagoCabeceraReference);
        }

        public Alquiler AlquilerLoad()
        {
            return Utility.Entity<Alquiler>.LoadReference(this.AlquilerReference);
        }

        #endregion
    }
}