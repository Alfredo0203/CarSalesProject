namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabProveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabProveedores()
        {
            tabCompras = new HashSet<tabCompras>();
        }

        [Key]
        public int idProveedor { get; set; }

        [Required]
        [StringLength(55)]
        public string proveedor { get; set; }

        [Required]
        [StringLength(55)]
        public string telefono { get; set; }

        [Required]
        [StringLength(55)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string estadoProveedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabCompras> tabCompras { get; set; }
    }
}
