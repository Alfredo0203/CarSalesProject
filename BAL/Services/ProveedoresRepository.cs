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
    public class ProveedoresRepository : IDisposable, IProveedoresRepository
    {
        private readonly Contexto contexto;

        //CONSTRUCTOR
        public ProveedoresRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        //MÉTODO PARA MOSTRAR LISTADO DE PROVEEDORES
        public List<tabProveedores> listaProveedores()
        {
            var proveedores = contexto.tabProveedores.ToList();
            return (proveedores);
        }

        //MÉTODO PARA AGREGAR O EDITAR PROVEEDORES
        public bool CreateOrAddProveedores(tabProveedores proveedores)
        {
            bool success;
            try
            {
                if (proveedores.idProveedor > 0)
                {
                    contexto.Entry(proveedores).State = EntityState.Modified;
                }
                else
                {
                    contexto.Entry(proveedores).State = EntityState.Added;
                }
                contexto.SaveChanges();
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }

        //OBTENER PROVEEDOR POR SU ID
        public tabProveedores ObtenerProveedorPorId(int IdProveedor)
        {
            var proveedor = contexto.tabProveedores.FirstOrDefault(x=>x.idProveedor == IdProveedor);
            return proveedor;
        }

        //MÉTODO PARA ELIMINAR PROVEEDOR
        public void EliminarProveedor(int idProveedor)
        {
            var proveedor = ObtenerProveedorPorId(idProveedor);
            if (proveedor != null)
            {
                    contexto.Entry(proveedor).State = EntityState.Deleted;
                    contexto.SaveChanges();
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
