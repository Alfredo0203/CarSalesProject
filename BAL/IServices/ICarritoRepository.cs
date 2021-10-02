using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface ICarritoRepository : IDisposable
    {
        //METODO LISTAR
        List<Carrito> ProductoEnCarrito(int idCliente);
        //MÉTODO GUARDAR
        void AgregarAlCarrito(Carrito carrito);
        //MÉTODO ACTUALIZAR
        void ActualizarCantidad(int id, int cantidad);
        //MÉTODO OBTENER POR ID
        Carrito ObtenerPorId(int id);
        //MÉTODO ELIMINAR
        void SacarDelCarrito(int id);

    }
}
