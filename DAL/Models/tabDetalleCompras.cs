namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabDetalleCompras
    {
        Contexto contexto = new Contexto();
        [Key]
        public int idDetalleCompra { get; set; }

        public int? fk_auto { get; set; }

        [StringLength(100)]
        public string marcaModelo { get; set; }

        public int cantidad { get; set; }

        public double precioCompra { get; set; }

        public double subTotal { get; set; }

        public int idCompra { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        public virtual tabCompras tabCompras { get; set; }
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

       

    }
}
