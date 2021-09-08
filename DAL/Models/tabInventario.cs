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
        private Contexto contexto = new Contexto();
        [Key]
        public int idInventario { get; set; }

        public int fk_auto { get; set; }

        public int existenciaProducto { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        [NotMapped]
        public string MarcaAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto== fk_auto).NombreMarca;
            }
        }

        [NotMapped]
        public string ModeloAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto == fk_auto).modelo;
            }
        }

        [NotMapped]
        public double PrecioAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(v => v.idAuto == fk_auto).precio;
            }
        }

        [NotMapped]
        public string Imagen
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto == fk_auto).imagen;
            }
        }

        [NotMapped]
        public DateTime Fecha
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto == fk_auto).fechaRegistro;
            }
        }
    }
}
