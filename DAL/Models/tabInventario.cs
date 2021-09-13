namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tabInventario")]
    public partial class tabInventario
    {
        Contexto contexto = new Contexto();
        [Key]
        public int idInventario { get; set; }

        public int fk_auto { get; set; }

        public int existenciaProducto { get; set; }
        public double precio{ get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        [NotMapped]
        public string MarcaAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(x => x.idAuto == fk_auto).NombreMarca;
            }
        }
        [NotMapped]
        public string ModeloAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(x => x.idAuto == fk_auto).modelo;
            }
        }

        [NotMapped]
        public string Image
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(x => x.idAuto == fk_auto).imagen;
            }
        }
    }
}
