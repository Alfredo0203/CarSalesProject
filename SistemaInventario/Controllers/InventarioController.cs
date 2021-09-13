using BAL.IServices;
using BAL.Services;
using DAL.Encriptado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class InventarioController : Controller
    {
        InterfazInventario inventarioRepository;
        public InventarioController()
        {
            this.inventarioRepository = new InventarioRepository(new DAL.Models.Contexto());
        }
        // GET: Inventario
        public ActionResult MostrarInventario()
        {
           var model = inventarioRepository.ListarInventario();
            return View(model);
        }
    }
}