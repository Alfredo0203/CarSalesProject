namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabCompras
    {
        private readonly Contexto contexto = new Contexto();
        [Key]
        public int idCompra { get; set; }

        public int fk_auto { get; set; }

        public DateTime fecha { get; set; }

        public int cantidad { get; set; }

        [StringLength(105)]
        public string descripcion { get; set; }

        public int fk_Proveedor { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        public virtual tabProveedores tabProveedores { get; set; }


        [NotMapped]
        public string MarcaAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto == fk_auto).NombreMarca;
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
                return contexto.tabAutos.FirstOrDefault(a => a.idAuto == fk_auto).precio;
            }
        }

        [NotMapped]
        public string NombreProveedor
        {
            get
            {
                return contexto.tabProveedores.FirstOrDefault(m => m.idProveedor == fk_Proveedor).proveedor;
            }
        }
    }
}
