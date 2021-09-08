using BAL.IServices;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class InventarioRepository : InterfazInventario, IDisposable
    {
        private Contexto contexto;
        public InventarioRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        public List<tabInventario> ListarInventario()
        {
            var listaInventario = contexto.tabInventario.ToList();

            return listaInventario;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
