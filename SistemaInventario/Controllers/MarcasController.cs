using BAL.IServices;
using BAL.Services;
using DAL.Seguridad;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    [Admin]
    public class MarcasController : Controller
    {
        private IMarcasRepository marcasRepository;

        public MarcasController() {
            this.marcasRepository = new MarcasRepository(new Contexto());
        }

        // GET: Marcas
        public ActionResult MostrarMarcas()
        {
            var listadoMarcas = marcasRepository.ListarMarcas();
            return View(listadoMarcas);
        }

        public ActionResult AgregarOEditarMarcas(int idMarca= 0)
        {
            var marca = new tabMarcas();
            if(idMarca > 0)
            {
                marca = marcasRepository.ObtenerMarcaPorId(idMarca);
            }
            return View(marca);
        }

        [HttpPost]
        public ActionResult AgregarOEditarMarcas(tabMarcas model)
        {
            if (ModelState.IsValid)
            {
                if(model.idMarca > 0)
                {
                    TempData["message"] = "Registro actualizado exitosamente";
                    marcasRepository.ActualizarMarcas(model);
                } 
                else
                {
                    TempData["message"] = "Registro agregado exitosamente";
                    marcasRepository.AgregarMarcas(model);
                }
                return RedirectToAction("MostrarMarcas");
            }
            return View(model);
        }

        public ActionResult EliminarMarcas(int id = 0, bool success = false)
        {
            if (id > 0 && success == true)
            {
                marcasRepository.EliminarMarcas(id);
            }
            return RedirectToAction("MostrarMarcas");
        }
    }
}