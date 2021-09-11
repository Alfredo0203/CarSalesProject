namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabClientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabClientes()
        {
            tabVentas = new HashSet<tabVentas>();
        }

        [Key]
        public int idCliente { get; set; }

        [Required]
        [StringLength(55)]
        public string nombre { get; set; }

        [Required]
        [StringLength(55)]
        public string telefono { get; set; }

        [Required]
        [StringLength(55)]
        public string direccion { get; set; }

        [StringLength(20)]
        public string estadoCliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabVentas> tabVentas { get; set; }
    }
}
