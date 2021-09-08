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
    public class ComprasController : Controller
    {
        private IComprasRepository comprasRepository;
        private IProveedoresRepository proveedoresRepositoty;
        private IAutosRepository autosRepository;
        //INICIALIZACIÓN DE LOS OBJETOS DE CLASE E INTERFACE
        public ComprasController()
        {
            this.comprasRepository = new ComprasRepository(new Contexto());
            this.proveedoresRepositoty = new ProveedoresRepository(new Contexto());
            this.autosRepository = new AutosRepository(new Contexto());
        }
        // MÉTODO LISTAR Compras
        public ActionResult MostrarCompras()
        {
   
              var listadoCompras = comprasRepository.ListarCompras();

                return View(listadoCompras );
           
        }

        // AGREGAR O EDITAR COMPRAS
        public ActionResult AgregarOEditarCompras(int id = 0)
        {
            ViewBag.listaAutos= SeleccionarAutos();
            ViewBag.listaProveedores = SeleccionarProveedores();
            var model = new tabCompras();
            if(id > 0)
            {
                model = comprasRepository.ObtenerComprasPorID(id);
            }
            return View(model);
        }

         
        [HttpPost]
        public ActionResult AgregarOEditarCompras(tabCompras model)
        {
            ViewBag.listaAutos = SeleccionarAutos();
            ViewBag.listaProveedores = SeleccionarProveedores();
            if(ModelState.IsValid)
            {
                if(model.idCompra >  0)
                {
                    comprasRepository.ActualizarCompras(model);
                }
                else
                {
                    comprasRepository.AgregarCompras(model);
                }
                return RedirectToAction("MostrarCompras");
            }
            return View(model);
        }

        //MÉTODO ELIMINAR
        public ActionResult EliminarCompras(int id = 0)
        {
            if (id > 0)
            {
                comprasRepository.EliminarCompras(id);
            }
            return RedirectToAction("MostrarCompras");
        }
        // MÉTODO SELECCIONAR DATOS DE TABLAS RELACIONADAS
        public List<SelectListItem> SeleccionarAutos()
        {
            var listaAutos = new List<SelectListItem>();
            foreach (var item in autosRepository.ListarAutos())
            {
                listaAutos.Add(new SelectListItem { Text = item.NombreMarca, Value = item.idAuto.ToString() });
            }
            return listaAutos;
        }

        public List<SelectListItem> SeleccionarProveedores()
        {
            var listaProveedores = new List<SelectListItem>();
            foreach (var item in proveedoresRepositoty.listaProveedores())
            {
                listaProveedores.Add(new SelectListItem { Text = item.proveedor, Value = item.idProveedor.ToString() });
            }
            return listaProveedores;
        }


    }
}
