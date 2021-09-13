using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
   public interface IDetalleVentasRepository : IDisposable
    {
        //METODO LISTAR
        List<tabDetalleVentas> ListarDetalleVentas();
        //METODO AGREGAR
        void AgregarVentas(tabDetalleVentas venta);
        //METODO OBTENER POR ID
        tabDetalleVentas ObtenerVentaPorID(int id);
        //METODO LISTAR ACTUALIZAR
        void ActualizarDetalleVentas(tabDetalleVentas venta);
        //METODO ELIMINAR
        void EliminarVentas(int id);
    }
}
