namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabAutos
    {
        Contexto contexto = new Contexto();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tabAutos()
        {
            tabDetalleCompras = new HashSet<tabDetalleCompras>();
            tabDetalleVentas = new HashSet<tabDetalleVentas>();
            tabInventario = new HashSet<tabInventario>();
        }


        [Key]
        public int idAuto { get; set; }

        public int fk_marca { get; set; }

        [Required]
        [StringLength(55)]
        public string placa { get; set; }

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

        //Retornar la fecha actual
        [Column(TypeName = "date")]
        public DateTime fechaRegistro {
            get { return DateTime.Now; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabDetalleCompras> tabDetalleCompras { get; set; }

        public virtual tabMarcas tabMarcas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabDetalleVentas> tabDetalleVentas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabInventario> tabInventario { get; set; }

        [NotMapped]
        public string NombreMarca 
        {
            get {
                return contexto.tabMarcas.FirstOrDefault(x => x.idMarca == fk_marca).marca;
            } 
        }
    }
}
