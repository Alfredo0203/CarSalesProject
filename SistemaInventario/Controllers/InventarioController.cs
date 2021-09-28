using BAL.IServices;
using BAL.Services;
using DAL.Models;
using DAL.Seguridad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class InventarioController : Controller
    {
        //:::::::::::::::::::::::::VARIABLES GLOBALES::::::::::::::::::::::::::::::::
        private IAutosRepository autosRepository;
        private readonly IMarcasRepository marcasRepository;
        Contexto contexto = new Contexto();

        InterfazInventario inventarioRepository;
        public InventarioController()
        {
            this.inventarioRepository = new InventarioRepository(new Contexto());
            this.autosRepository = new AutosRepository(new Contexto());
            this.marcasRepository = new MarcasRepository(new Contexto());

        }
        // GET: Inventario
        public ActionResult MostrarInventario()
        {
           var model = inventarioRepository.ListarInventario();
            return View(model);
        }

        //AGREGAR AUTOS
        [Admin]
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
        [Admin]
        [HttpPost]
        public ActionResult AgregarOEditarAutos(tabAutos model, HttpPostedFileBase imagen)
        {
            ViewBag.listaMarcas = SeleccionarMarcas();
            if (imagen != null) model.imagen = GuardarImagen(imagen);
            if (model.imagen == "0") ModelState.AddModelError("Mensaje", "La imagen es obligatoria");
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
        [Admin]
        public ActionResult EliminarAutos(int id = 0)
        {

            if (id > 0)
            {
                    autosRepository.EliminarAutos(id);
            }
           
            
            return RedirectToAction("MostrarInventario");
        }

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

        //Método Guardar Imagen

        public string GuardarImagen(HttpPostedFileBase imagen)
        {

            string nombre = Path.GetFileName(imagen.FileName);

            string RutaSitio = Server.MapPath("~/");

            string PathArchivo1 = Path.Combine(RutaSitio + "Content/img_cars/" + nombre);



            if (System.IO.File.Exists(PathArchivo1))
            {
                int i = 1;
                while (System.IO.File.Exists(PathArchivo1))
                {
                    string extencion = Path.GetExtension(imagen.FileName);
                    string cambiarnombre = Path.GetFileNameWithoutExtension(imagen.FileName);
                    PathArchivo1 = Path.Combine(RutaSitio + "Content/img_cars" + cambiarnombre + i + extencion);
                    i++;
                }

            }
            imagen.SaveAs(PathArchivo1);
            return nombre;
        }

    }
}