namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabVentas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabVentas()
        {
            tabDetalleVentas = new HashSet<tabDetalleVentas>();
            this.Fecha = DateTime.Now;
        }
        
        [Key]
        public int IdVenta { get; set; }


        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int? FkCliente { get; set; }

        public double Total { get; set; }

        public virtual tabClientes tabClientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabDetalleVentas> tabDetalleVentas { get; set; }
    }
}
