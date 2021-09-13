using BAL.IServices;
using BAL.Services;
using DAL.Encriptado;
using DAL.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    
    public class AutosController : Controller
    {
        private IAutosRepository autosRepository;
        private readonly IMarcasRepository marcasRepository;
        public AutosController()
        {
            this.autosRepository = new AutosRepository(new Contexto());
            this.marcasRepository = new MarcasRepository(new Contexto());
        }
        // GET: Autos
        public ActionResult MostrarAutos()
        {
           var listaAutos = autosRepository.ListarAutos();
            return View(listaAutos);
        }
        [Permisos]
        public ActionResult AgregarOEditarAutos(int id = 0)
        {

            ViewBag.listaMarcas = SeleccionarMarcas();
            var auto = new tabAutos();
            if(id > 0)
            {
                auto = autosRepository.ObtenerPorId(id);
            }

            return View(auto);
        }

        [Permisos]
        [HttpPost]
        public ActionResult AgregarOEditarAutos(tabAutos model)
        {

           
            if (ModelState.IsValid)
            {
               
                if (model.idAuto > 0)
                {
                    autosRepository.ActualizarAutos(model);
                }
                else
                {
                    autosRepository.GuardarAutos(model);
                }
                return RedirectToAction("MostrarAutos");
            }

            return View(model);
        }
        [Permisos]
        public ActionResult EliminarAutos(int id = 0)
        {
            if(id > 0)
            {

                    autosRepository.EliminarAutos(id);

            }
            return RedirectToAction("MostrarAutos");
        }
        [Permisos]

        //MÉTODO AGREGAR NARCAS AL ELEMENTO SelectListItem
        public List<SelectListItem> SeleccionarMarcas()
        {
            var listaMarcas = new List<SelectListItem>();

            foreach (var item in marcasRepository.ListarMarcas())
            {
                listaMarcas.Add(new SelectListItem { Text = item.marca, Value = item.idMarca.ToString() });

            }
            return listaMarcas;
        }


    }
}
