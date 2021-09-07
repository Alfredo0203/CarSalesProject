namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabAutos
    {
        private Contexto contexto =new Contexto();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabAutos()
        {
            tabCompras = new HashSet<tabCompras>();
            tabVentas = new HashSet<tabVentas>();
            tabInventario = new HashSet<tabInventario>();
        }

        [Key]
        public int idAuto { get; set; }

        [Required]
        [StringLength(55)]
        public string codigo { get; set; }

        public int fk_marca { get; set; }

        [Required]
        [StringLength(55)]
        public string placa { get; set; }

        public double precio { get; set; }

        [Required]
        [StringLength(55)]
        public string imagen { get; set; }

        [Required]
        [StringLength(55)]
        public string modelo { get; set; }

        [Required]
        [StringLength(55)]
        public string color { get; set; }

        [Required]
        [StringLength(55)]
        public string motor { get; set; }

        [Required]
        [StringLength(55)]
        public string descripcion { get; set; }

        public DateTime fechaLanzamiento { get; set; }

        public DateTime fechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabCompras> tabCompras { get; set; }

        public virtual tabMarcas tabMarcas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabVentas> tabVentas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabInventario> tabInventario { get; set; }

        [NotMapped]
        public string NombreMarca
        {
            get
            {
                return contexto.tabMarcas.FirstOrDefault(x => x.idMarca == fk_marca).marca;
            }
        }
    }
}
