using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IClientesRepositoty : IDisposable
    {
        //MÉTODO LISTAR CLIENTES
        List<tabClientes> ListaClientes();
        //MÉTODO AGREGAR CLIENTES
        void AgregarClientes(tabClientes clientes);
        //MÉTODO ACTUALIZAR CLIENTES
        void ActualizarClientes(tabClientes clientes);
        //MÉTODO OBTENER ID CLIENTE 
        tabClientes ObtenerClientesPorID(int idCliente);
        //MÉTODO ELIMINAR CLIENTE
        void EliminarCliente(int idCliente);
    }
}
