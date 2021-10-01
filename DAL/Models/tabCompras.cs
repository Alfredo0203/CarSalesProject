namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabCompras
    {
        Contexto contexto = new Contexto();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabCompras()
        {
            tabDetalleCompras = new HashSet<tabDetalleCompras>();
            this.Fecha = DateTime.Now;
        }

        [Key]
        public int IdCompra { get; set; }


        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int? FkProveedor { get; set; }

        public double Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabDetalleCompras> tabDetalleCompras { get; set; }

        public virtual tabProveedores tabProveedores { get; set; }

        
    }
}
