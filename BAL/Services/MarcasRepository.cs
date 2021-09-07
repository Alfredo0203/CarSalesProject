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
    public class MarcasRepository : IMarcasRepository, IDisposable
    {
        private readonly Contexto contexto;

        public MarcasRepository(Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        // IMPLEMENTACIÓN DEL MÉTODO LISTAR
        public List<tabMarcas> ListarMarcas()
        {
           
                var listaMarcas = contexto.tabMarcas.ToList();
                return listaMarcas;

        }
        // IMPLEMENTACIÓN DEL MÉTODO AGREGAR
        public void AgregarMarcas(tabMarcas marca)
        {
            try
            {
                contexto.Entry(marca).State = EntityState.Added;
                contexto.SaveChanges();
            }
            catch (Exception) { }
           
        }
        // IMPLEMENTACIÓN DEL MÉTODO ACTUALIZAR
        public void ActualizarMarcas(tabMarcas marca)
        {
            try
            {
                contexto.Entry(marca).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception) { }
        }
        // IMPLEMENTACIÓN DEL MÉTODO ELIMINAR
        public void EliminarMarcas(int id)
        {
            var model = ObtenerMarcaPorId(id);
            if(model != null)
            {
                contexto.Entry(model).State = EntityState.Deleted;
            }
        }

        // IMPLEMENTACIÓN DEL MÉTODO OBTENER POR ID
        public tabMarcas ObtenerMarcaPorId(int id)
        {
            var marcaEncontrada = contexto.tabMarcas.FirstOrDefault(x => x.idMarca == id);
            return marcaEncontrada;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
