using BAL.IServices;
using BAL.Services;
using DAL.Models;
using DAL.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    //[Permisos]
    public class InventarioController : Controller
    {
        //:::::::::::::::::::::::::VARIABLES GLOBALES::::::::::::::::::::::::::::::::
        private IAutosRepository autosRepository;
        private readonly IMarcasRepository marcasRepository;
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        InterfazInventario inventarioRepository;
        public InventarioController()
        {
            this.inventarioRepository = new InventarioRepository(new Contexto());
            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            this.autosRepository = new AutosRepository(new Contexto());
            this.marcasRepository = new MarcasRepository(new Contexto());
            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        }
        // GET: Inventario
        public ActionResult MostrarInventario()
        {
           var model = inventarioRepository.ListarInventario();
            return View(model);
        }

        //AGREGAR AUTOS
        [Permisos]
        public ActionResult AgregarOEditarAutos(int id = 0)
        {
            ViewBag.listaMarcas = SeleccionarMarcas();
            var auto = new tabAutos();
            if (id > 0)
            {
                auto = autosRepository.ObtenerPorId(id);
            }

            return View(auto);
        }

        //EDITAR AUTOS
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
                return RedirectToAction("MostrarInventario");
            }

            return View(model);
        }

        //MÉTODO ELIMINAR AUTOS
        [Permisos]
        public ActionResult EliminarAutos(int id = 0)
        {
            if (id > 0)
            {
                autosRepository.EliminarAutos(id);

            }
            return RedirectToAction("MostrarInventario");
        }
        [Permisos]

        //MÉTODO AGREGAR MARCAS AL ELEMENTO SelectListItem
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