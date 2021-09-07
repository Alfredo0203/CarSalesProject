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
    public class AutosRepository : IAutosRepository, IDisposable
    {
        private readonly Contexto contexto;

        public AutosRepository( Contexto _contexto)
        {
            this.contexto = _contexto;
        }

        //IMPLENTACIÓN DEL MÉTODO LISTAR
        public List<tabAutos> ListarAutos()
        {
            var listAutos = contexto.tabAutos.ToList();

            return listAutos;
        }
        //IMPLENTACIÓN DEL MÉTODO AGREGAR
        public void GuardarAutos(tabAutos auto)
        {
            contexto.Entry(auto).State = EntityState.Added;
            contexto.SaveChanges();
        }

        public tabAutos ObtenerPorId(int id)
        {
            var autoEncontrado = contexto.tabAutos.FirstOrDefault(x => x.idAuto == id);
            return autoEncontrado;

        }
        //IMPLENTACIÓN DEL MÉTODO ACTUALIZAR
        public void ActualizarAutos(tabAutos auto)
        {
            contexto.Entry(auto).State = EntityState.Modified;
            contexto.SaveChanges();
        }
        //IMPLENTACIÓN DEL MÉTODO ELIMINAR
        public void EliminarAutos(int id)
        {
            var model = ObtenerPorId(id);

            if(model != null)
            {
                contexto.Entry(model).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
