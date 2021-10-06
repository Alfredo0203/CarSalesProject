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
        // IMPLEMENTACIÓN DEL MÉTODO LISTAR CLIENTES
        public List<tabClientes> ListaClientes()
        {
            var listaclientes = contexto.tabClientes.ToList();

            return listaclientes;
        }

        // IMPLEMENTACIÓN DEL MÉTODO ACTUALIZAR CLIENTES
        public void ActualizarClientes(tabClientes clientes)
        {
            contexto.Entry(clientes).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        // IMPLEMENTACIÓN DEL MÉTODO OBTENER CLIENTE POR ID

        public tabClientes ObtenerClientesPorID(int IdCl)
        {
            var model = contexto.tabClientes.FirstOrDefault(x => x.idCliente == IdCl);
            return model;
        }

        // IMPLEMENTACIÓN DEL MÉTODO AGREGAR CLIENTES
        public void AgregarClientes(tabClientes clientes)
        {
            contexto.Entry(clientes).State = EntityState.Added;
            contexto.SaveChanges();
        }
        // IMPLEMENTACIÓN DEL MÉTODO ELIMINAR CLIENTES
        public void EliminarCliente(int idCliente)
        {
            var model = ObtenerClientesPorID(idCliente);
            if (model != null)
            {
                try
                {
                    contexto.Entry(model).State = EntityState.Deleted;
                    contexto.SaveChanges();
                }
                catch (Exception)
                {

                }
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool ExisteDato(string Dato)
        {
            bool existe = false;
            using (Contexto db = new Contexto())
            {
                existe = contexto.tabClientes.Any(x => x.correo == Dato);
                if (existe == false) existe = contexto.tabUsuarios.Any(x => x.correo == Dato);
            }
            return existe;
        }
    }
}
