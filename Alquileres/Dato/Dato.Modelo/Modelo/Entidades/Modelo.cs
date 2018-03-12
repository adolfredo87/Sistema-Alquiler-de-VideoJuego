﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(Modelo.MetaData))]
    [DisplayName("Modelo Producto")]
    public partial class Modelo
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID"), StringLength(50)]
            public int ID { get; set; }

            [Required, DisplayName("Codigo"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Modelo del Producto"), StringLength(100)]
            public String Descripcion { get; set; }

        }

        #region Metodos Extendidos del Entities Framework
        #endregion
    }
}
