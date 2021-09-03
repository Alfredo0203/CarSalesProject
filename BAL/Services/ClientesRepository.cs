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
   public class ClientesRepository : IClientesRepositoty, IDisposable
    {
        private readonly Contexto contexto;
        

        public ClientesRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }
        // IMPLEMENTACIÓN DEL MÉTODO AGREGAR CLIENTES
        public void AgregarClientes(tabClientes clientes)
        {
            contexto.Entry(clientes).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<tabClientes> ListaClientes()
        {
            var listaclientes = contexto.tabClientes.ToList();

            return listaclientes;
        }

    }
}
