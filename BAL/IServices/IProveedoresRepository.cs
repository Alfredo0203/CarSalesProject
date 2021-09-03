using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IServices
{
    public interface IProveedoresRepository : IDisposable
    {
        List<tabProveedores> listaProveedores();
        bool CreateOrAddProveedores(tabProveedores proveedores);
        tabProveedores ObtenerProveedorPorId(int idProveedor);
        void EliminarProveedor(int idProveedor);
    }

}
