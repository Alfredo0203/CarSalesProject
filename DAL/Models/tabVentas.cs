namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabVentas
    {
        private Contexto contexto = new Contexto();
        [Key]
        public int idVenta { get; set; }

        public int fk_auto { get; set; }

        public DateTime fecha { get; set; }

        public int cantidad { get; set; }

        [StringLength(105)]
        public string descripcion { get; set; }

        public int fk_Cliente { get; set; }

        public virtual tabAutos tabAutos { get; set; }

        public virtual tabClientes tabClientes { get; set; }

        [NotMapped]
        public string MarcaAuto
        {
            get
            {
                return contexto.tabAutos.FirstOrDefault(m => m.idAuto == fk_auto).NombreMarca;
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
        public string NombreCliente
        {
            get
            {
                return contexto.tabClientes.FirstOrDefault(m => m.idCliente == fk_Cliente).nombre;
            }
        }
    }
   
}
