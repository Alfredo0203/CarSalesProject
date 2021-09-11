namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tabInventario")]
    public partial class tabInventario
    {
        [Key]
        public int idInventario { get; set; }

        public int fk_auto { get; set; }

        public int existenciaProducto { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public virtual tabAutos tabAutos { get; set; }
    }
}
