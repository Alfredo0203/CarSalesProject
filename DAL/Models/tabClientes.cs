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
            this.isActivo = true;
        }

        [Key]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(55)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Ingrese n�mero de tel�fono")]
     
        public string telefono { get; set; }

        [Required(ErrorMessage = "La direcci�n es requerida")]

        public string direccion { get; set; }

        public bool isActivo { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo v�lido")]
        public string correo { get; set; }

        [Required(ErrorMessage = "La contrase�a es requerida")]
        public string pass { get; set; }

        [NotMapped]
        [Compare(nameof(pass), ErrorMessage = "Las contrase�as no coinciden")]
        public string ConfirmarPass { get; set; }
        public Rol rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tabVentas> tabVentas { get; set; }
    }
}
