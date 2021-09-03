using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class ProveedoresRepository : IDisposable, IProveedoresRepository
    {
        private readonly Contexto contexto;

        //Constructor
        public ProveedoresRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        //Método para retornar listado de proveedores
        public List<tabProveedores> listaProveedores()
        {
            var proveedores = contexto.tabProveedores.ToList();
            return (proveedores);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
