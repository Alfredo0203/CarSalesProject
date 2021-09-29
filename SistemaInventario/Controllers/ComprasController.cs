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
    public class ComprasController : Controller
    {
        private Contexto contexto = new Contexto();
        private IDetalleComprasRepository comprasRepository;
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
            try
            {
                var listadoCompras = comprasRepository.ListarDetalleCompras();
                ViewBag.Compras = contexto.tabCompras.ToList();
                return View(listadoCompras);
            }
            catch (Exception)
            {
                return View();
            }
             
            
           
        }

        // AGREGAR O EDITAR COMPRAS
        public ActionResult AgregarOEditarCompras()
        {
            ViewBag.listaAutos= SeleccionarAutos();
            ViewBag.listaProveedores = SeleccionarProveedores();
            var model = contexto.tabInventario.ToList();
           
            return View(model);
        }

         
        [HttpPost]
        public ActionResult AgregarOEditarCompras(tabDetalleCompras model)
        {
            ViewBag.listaAutos = SeleccionarAutos();
            ViewBag.listaProveedores = SeleccionarProveedores();
            if(ModelState.IsValid)
            {
                if(model.idCompra >  0)
                {
                    comprasRepository.ActualizarDetalleCompras(model);
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
