using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IVentasRepository : IDisposable
    {
        //METODO LISTAR
        List<tabVentas> ListarVentas();
        //METODO AGREGAR
        void AgregarVentas(tabVentas venta);
        //METODO OBTENER POR ID
        tabVentas ObtenerVentaPorID(int id);
        //METODO LISTAR ACTUALIZAR
        void ActualizarVentas(tabVentas venta);
        //METODO ELIMINAR
        void EliminarVentas(int id);
    }
}
