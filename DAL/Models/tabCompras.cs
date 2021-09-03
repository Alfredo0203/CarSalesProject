namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabCompras
    {
        [Key]
        public int idCompra { get; set; }

        public int fk_auto { get; set; }

        public DateTime fecha { get; set; }

        public int cantidad { get; set; }

        [StringLength(105)]
        public string descripcion { get; set; }

        public int fk_Proveedor { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        public virtual tabProveedores tabProveedores { get; set; }
    }
}
