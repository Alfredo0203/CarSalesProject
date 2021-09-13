namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabUsuarios
    {
        [Key]
        public int idUsuario { get; set; }
        [Required] 
        [StringLength(50)]
        public string nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string apellido { get; set; }
        [Required]
        public int edad { get; set; }
        [Required]
        [StringLength(50)]
        public string correo { get; set; }

        [Required]
        [StringLength(50)]
        public string pass { get; set; }
        [Required]
        public bool isActivo { get; set; }

        public int rol { get; set; }
        [Required]
        public Rol rol { get; set; }
    }

    //CLASE DE TIPO ENUM PARA LOS ROLES
    public enum Rol
    { 
        [Description("Administrador")]
        admin,
        [Description("Vendedor")]
        vendedor,
        [Description("Cliente")]
        cliente
    }
}
