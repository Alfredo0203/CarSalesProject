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

        public virtual DbSet<Carrito> Carrito { get; set; }
        public virtual DbSet<tabAutos> tabAutos { get; set; }
        public virtual DbSet<tabClientes> tabClientes { get; set; }
        public virtual DbSet<tabCompras> tabCompras { get; set; }
        public virtual DbSet<tabDetalleCompras> tabDetalleCompras { get; set; }
        public virtual DbSet<tabDetalleVentas> tabDetalleVentas { get; set; }
        public virtual DbSet<tabInventario> tabInventario { get; set; }
        public virtual DbSet<tabMarcas> tabMarcas { get; set; }
        public virtual DbSet<tabProveedores> tabProveedores { get; set; }
        public virtual DbSet<tabUsuarios> tabUsuarios { get; set; }
        public virtual DbSet<tabVentas> tabVentas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .HasMany(e => e.Carrito)
                .WithRequired(e => e.tabAutos)
                .HasForeignKey(e => e.FkAuto);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabDetalleCompras)
                .WithOptional(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabDetalleVentas)
                .WithOptional(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto);

            modelBuilder.Entity<tabAutos>()
                .HasMany(e => e.tabInventario)
                .WithRequired(e => e.tabAutos)
                .HasForeignKey(e => e.fk_auto);

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
                .Property(e => e.estadoCliente)
                .IsFixedLength();

            modelBuilder.Entity<tabClientes>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<tabClientes>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<tabClientes>()
                .HasMany(e => e.tabVentas)
                .WithOptional(e => e.tabClientes)
                .HasForeignKey(e => e.FkCliente);

            modelBuilder.Entity<tabCompras>()
                .HasMany(e => e.tabDetalleCompras)
                .WithRequired(e => e.tabCompras)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tabDetalleCompras>()
                .Property(e => e.marcaModelo)
                .IsFixedLength();

            modelBuilder.Entity<tabDetalleVentas>()
                .Property(e => e.marcaModelo)
                .IsFixedLength();

            modelBuilder.Entity<tabInventario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<tabMarcas>()
                .Property(e => e.marca)
                .IsUnicode(false);

            modelBuilder.Entity<tabMarcas>()
                .HasMany(e => e.tabAutos)
                .WithRequired(e => e.tabMarcas)
                .HasForeignKey(e => e.fk_marca);

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
                .Property(e => e.estadoProveedor)
                .IsFixedLength();

            modelBuilder.Entity<tabProveedores>()
                .HasMany(e => e.tabCompras)
                .WithOptional(e => e.tabProveedores)
                .HasForeignKey(e => e.FkProveedor);

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
        }
    }
}
