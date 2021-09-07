using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
  public  interface IAutosRepository : IDisposable
    {
        //METODO LISTAR
        List<tabAutos> ListarAutos();
        //MÉTODO GUARDAR
        void GuardarAutos(tabAutos auto);
        //MÉTODO ACTUALIZAR
        void ActualizarAutos(tabAutos auto);
        //MÉTODO OBTENER POR ID
        tabAutos ObtenerPorId(int id);
        //MÉTODO ELIMINAR
        void EliminarAutos(int id);
    }
}
