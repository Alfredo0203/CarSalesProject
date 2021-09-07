using BAL.IServices;
using BAL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class AutosController : Controller
    {
        IAutosRepository autosRepository;
        IMarcasRepository marcasRepository;
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

        public ActionResult AgregarOEditarAutos(int id = 0)
        {
            var listaMarcas = new List<SelectListItem>();

            foreach (var item in marcasRepository.ListarMarcas())
            {
                listaMarcas.Add(new SelectListItem { Text = item.marca, Value = item.idMarca.ToString() });

            }
            ViewBag.listaMarcas = listaMarcas;
            var auto = new tabAutos();
            if(id > 0)
            {
                auto = autosRepository.ObtenerPorId(id);
            }

            return View(auto);
        }
        [HttpPost]
        public ActionResult AgregarOEditarAutos(tabAutos model)
        {
            var listaMarcas = new List<SelectListItem>();

            foreach (var item in marcasRepository.ListarMarcas())
            {
                listaMarcas.Add(new SelectListItem { Text = item.marca, Value = item.idMarca.ToString() });

            }
            ViewBag.listaMarcas = listaMarcas;
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

        public ActionResult EliminarAutos(int id = 0)
        {
            if(id > 0)
            {
                try
                {
                    autosRepository.EliminarAutos(id);
                }catch(Exception e)
                {

                }
            }
            return RedirectToAction("MostrarAutos");
        }
           
        }
    }
