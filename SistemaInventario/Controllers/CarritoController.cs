using BAL.ProductoParaVender;
using DAL.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult MostrarCarrito()
        {
            var autos = AutosAVender.listaAutosAVender.ToList();
            return View(autos);
        }
    }
}