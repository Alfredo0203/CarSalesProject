using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace BAL.Services
{
    public class CarritoRepository : ICarritoRepository, IDisposable
    {
        private readonly Contexto contexto;


        public CarritoRepository(Contexto contexto1)
        {
            this.contexto = contexto1;
        }


        public void ActualizarCantidad(int id, int cantidad)
        {
            var carrito = ObtenerPorId(id);
            carrito.Cantidad = cantidad;
            contexto.Entry(carrito).State = EntityState.Modified;
            contexto.SaveChanges();

        }

        public void AgregarAlCarrito(Carrito carrito)
        {
            contexto.Entry(carrito).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Carrito ObtenerPorId(int id)
        {
            var modelo = contexto.Carrito.FirstOrDefault(x => x.FkAuto == id);
            return modelo;
        }

        public List<Carrito> ProductoEnCarrito(int id)
        {
            
            var ProductoEnCarrito = contexto.Carrito.Where(x => x.IdCliente == id).ToList();
            return ProductoEnCarrito;
        }

        public void SacarDelCarrito(int id)
        {
            var model = ObtenerPorId(id);

            if (model != null)
            {
                contexto.Entry(model).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}
