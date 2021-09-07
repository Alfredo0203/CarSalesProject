using System;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IMarcasRepository : IDisposable
    {
        //MÉTODO LISTAR
        List<tabMarcas> ListarMarcas();
        //MÉTODO AGREGAR
        void AgregarMarcas(tabMarcas marca);
        //MÉTODO ACTULIZAR
        void ActualizarMarcas(tabMarcas marca);
        //MÉTODO ELIMINAR ()
        void EliminarMarcas(int id);
        //MÉTODO OBTENER POR ID
        tabMarcas ObtenerMarcaPorId(int id);
    }
}
