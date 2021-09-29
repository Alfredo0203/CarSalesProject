namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Carrito")]
    public partial class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public int IdCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double SubTotal { get; set; }

        [NotMapped]
        public static double TotalAPagar { get; set; }
    }
}
