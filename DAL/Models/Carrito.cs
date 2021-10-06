namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public int IdCliente { get; set; }

        public int FkAuto { get; set; }

        public int Cantidad { get; set; }

        public virtual tabClientes tabClientes { get; set; }

        public virtual tabAutos tabAutos { get; set; }
    }
}
