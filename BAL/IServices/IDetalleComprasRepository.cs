using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IDetalleComprasRepository : IDisposable
    {
        //MÉTODO LISTAR
        List<tabDetalleCompras> ListarDetalleCompras();
        // MÉTODO AGREGAR
        void AgregarCompras(tabDetalleCompras compra);

        //BUSCAR POR ID
        tabDetalleCompras ObtenerComprasPorID(int id);
        // ACTUALZAR
        void ActualizarDetalleCompras(tabDetalleCompras compra);
        //ELIMINAR 
        void EliminarCompras(int id);
    }
}
