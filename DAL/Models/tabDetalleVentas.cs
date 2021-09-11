namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabDetalleVentas
    {
        Contexto contexto = new Contexto();
        [Key]
        public int idDetalleVenta { get; set; }

        public int? fk_auto { get; set; }

        [StringLength(100)]
        public string marcaModelo { get; set; }

        public int cantidad { get; set; }

        public double precio { get; set; }

        public double subTotal { get; set; }

        public int idVenta { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        public virtual tabVentas tabVentas { get; set; }

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
        public double PrecioAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(x => x.idAuto == fk_auto).precio;
            }
        }

    }
}
