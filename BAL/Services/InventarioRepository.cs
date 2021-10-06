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
        //METODO PARA MODIFICAR INVENTARIO
        public void ModificarInventario(tabInventario inv)
        {
            contexto.Entry(inv).State = EntityState.Modified;
            contexto.SaveChanges();
        }
        //OBTENER INVENTARIO POR ID
        public tabInventario ObtenerInventarioPorID(int idInventario)
        {
            var inventario = contexto.tabInventario.FirstOrDefault(x => x.idInventario == idInventario);
            return inventario;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

      
    }
}
