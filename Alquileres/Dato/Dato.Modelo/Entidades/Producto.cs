using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(Producto.MetaData))]
    [DisplayName("Productos")]
    public partial class Producto
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Producto"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Nombre Producto"), StringLength(200)]
            public String Nombre { get; set; }

            [Required, DisplayName("Marca Producto"), StringLength(200)]
            public String Marca { get; set; }

            [Required, DisplayName("Categoria Producto")]
            public CategoriaProducto CategoriaProducto { get; set; }
        }

        #region Metodos Extendidos del Entities Framework

        public CategoriaProducto CategoriaProductoLoad()
        {
            return Utility.Entity<CategoriaProducto>.LoadReference(this.CategoriaProductoReference);
        }

        #endregion
    }
}