using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<tabAutos> tabAutos { get; set; }
        public virtual DbSet<tabClientes> tabClientes { get; set; }
        public virtual DbSet<tabCompras> tabCompras { get; set; }
        public virtual DbSet<tabInventario> tabInventario { get; set; }
        public virtual DbSet<tabMarcas> tabMarcas { get; set; }
        public virtual DbSet<tabProveedores> tabProveedores { get; set; }
        public virtual DbSet<tabUsuarios> tabUsuarios { get; set; }
        public virtual DbSet<tabVentas> tabVentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tabAutos>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.placa)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.modelo)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.motor)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabCompras)
                .WithRequired(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabVentas)
                .WithRequired(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabInventario)
                .WithRequired(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabClientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tabClientes>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<tabClientes>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<tabClientes>()
                .HasMany(e => e.tabVentas)
                .WithRequired(e => e.tabClientes)
                .HasForeignKey(e => e.fk_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabCompras>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tabMarcas>()
                .Property(e => e.marca)
                .IsUnicode(false);

            modelBuilder.Entity<tabMarcas>()
                .HasMany(e => e.tabAutos)
                .WithRequired(e => e.tabMarcas)
                .HasForeignKey(e => e.fk_marca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabProveedores>()
                .Property(e => e.proveedor)
                .IsUnicode(false);

            modelBuilder.Entity<tabProveedores>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<tabProveedores>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<tabProveedores>()
                .HasMany(e => e.tabCompras)
                .WithRequired(e => e.tabProveedores)
                .HasForeignKey(e => e.fk_Proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabUsuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tabUsuarios>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<tabUsuarios>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<tabUsuarios>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<tabVentas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);
        }
    }
}
