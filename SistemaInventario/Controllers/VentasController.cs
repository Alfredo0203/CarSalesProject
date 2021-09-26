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
    //[Permisos]
    public class VentasController : Controller
    {
        Contexto contexto = new Contexto();
        private IDetalleVentasRepository detalleVentasRepository;
        private IAutosRepository autosRepository;
        private IClientesRepositoty clientesRepositoty;
        public VentasController()
        {
            this.detalleVentasRepository = new VentasRepository(new Contexto());
            this.autosRepository = new AutosRepository(new Contexto());
            this.clientesRepositoty = new ClientesRepository(new Contexto());
        }
        // GET: Ventas
        public ActionResult MostrarVentas()
        {
            try
            {
                var model = detalleVentasRepository.ListarDetalleVentas();
                ViewBag.Ventas = contexto.tabVentas.ToList();
                return View(model);
            } 
            catch(Exception )
            {
                return View();
            }
        }

        public ActionResult AgregarOEditarVentas(int id = 0)
        {
            var model = new tabDetalleVentas();
            ViewBag.listaAutos = SeleccionarAutos();
            ViewBag.listaClientes = SeleccionarClientes();
            if (id > 0)
            {
                model = detalleVentasRepository.ObtenerVentaPorID(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarOEditarVentas(tabDetalleVentas venta)
        {
            ViewBag.listaAutos = SeleccionarAutos();
            ViewBag.listaClientes = SeleccionarClientes();
            if (ModelState.IsValid)
            {
                if (venta.idVenta > 0)
                {
                    detalleVentasRepository.ActualizarDetalleVentas(venta);
                 } else
                {
                    detalleVentasRepository.AgregarVentas(venta);
                }
                return RedirectToAction("MostrarVentas");
            }
            return View(venta);
        }


        public ActionResult EliminarVentas(int id = 0)
        {
            detalleVentasRepository.EliminarVentas(id);
            return RedirectToAction("MostrarVentas");
        }



        public List<SelectListItem> SeleccionarAutos()
        {
            var ListaAutos = new List<SelectListItem>();
            foreach(var item in autosRepository.ListarAutos())
            {
                ListaAutos.Add(new SelectListItem { Text = item.NombreMarca, Value = item.idAuto.ToString() });
            }
            return ListaAutos;
        }

        public List<SelectListItem> SeleccionarClientes()
        {
            var ListaClientes = new List<SelectListItem>();
            foreach(var item in clientesRepositoty.ListaClientes())
            {
                ListaClientes.Add(new SelectListItem { Text = item.nombre, Value = item.idCliente.ToString() });
            }
            return ListaClientes;
        }
    }
}