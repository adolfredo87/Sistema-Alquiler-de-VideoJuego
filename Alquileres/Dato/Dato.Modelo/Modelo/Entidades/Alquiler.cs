﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilidad;

namespace Dato.Modelo
{
    [MetadataType(typeof(Alquiler.MetaData))]
    [DisplayName("Alquileres")]
    public partial class Alquiler
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Alquiler"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Cliente")]
            public Cliente Cliente { get; set; }

            [Required, DisplayName("Producto")]
            public Producto Producto { get; set; }

            [Required, DisplayName("Desde")]
            public DateTime FechaDesde { get; set; }

            [Required, DisplayName("Hasta")]
            public DateTime FechaHasta { get; set; }

            [Required, DisplayName("Tiempo en Hora"), StringLength(20)]
            public String TiempoHora { get; set; }

            [Required, DisplayName("Tiempo en Dia"), StringLength(20)]
            public String TiempoDia { get; set; }

            [Required, DisplayName("Tiempo en Semana"), StringLength(20)]
            public String TiempoSemana { get; set; }

            [Required, DisplayName("Precio Estimado del Alquiler")]
            public Double PrecioEstimado { get; set; }

            [Required, DisplayName("Estatus")]
            public int Estatus { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public Cliente ClienteLoad()
        {
            return Utility.Entity<Cliente>.LoadReference(this.ClienteReference);
        }

        public Producto ProductoLoad()     
        {
            return Utility.Entity<Producto>.LoadReference(this.ProductoReference);
        }

        public List<Int32> ToSelectListEstatus()
        {
            List<int> estatus = new List<int>(new int[] { 0, 1, 2 });
            return estatus;
        }

        #endregion
    }
}