using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ComprasRepository : IDetalleComprasRepository, IDisposable
    {
        private readonly Contexto contexto;
        public ComprasRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        //MÉTODO LISTAR
        public List<tabDetalleCompras> ListarDetalleCompras()
        {
            var listaDetalleCompras = contexto.tabDetalleCompras.ToList();
            return listaDetalleCompras;

        }
        // MÉTODO AGREGAR
        public void AgregarCompras(tabDetalleCompras compra)
        {
            contexto.Entry(compra).State = EntityState.Added;
            contexto.SaveChanges();
        }

        //BUSCAR POR ID
        public tabDetalleCompras ObtenerComprasPorID(int id)
        {
            var compraEncontrada = contexto.tabDetalleCompras.FirstOrDefault(c => c.idCompra== id);
            return compraEncontrada;
        }
        // ACTUALZAR
        public void ActualizarDetalleCompras(tabDetalleCompras compra)
        {
            contexto.Entry(compra).State = EntityState.Modified;
            contexto.SaveChanges();
        }
        //ELIMINAR 
        public void EliminarCompras(int id)
        {
            var model = ObtenerComprasPorID(id);
            contexto.Entry(model).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
