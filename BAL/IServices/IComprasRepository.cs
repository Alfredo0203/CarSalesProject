using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IComprasRepository : IDisposable
    {
        //MÉTODO LISTAR
        List<tabCompras> ListarCompras();
        // MÉTODO AGREGAR
        void AgregarCompras(tabCompras compra);

        //BUSCAR POR ID
        tabCompras ObtenerComprasPorID(int id);
        // ACTUALZAR
        void ActualizarCompras(tabCompras compra);
        //ELIMINAR 
        void EliminarCompras(int id);
    }
}
