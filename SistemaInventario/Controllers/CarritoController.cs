using BAL.ProductoParaVender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
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