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
    public class ProveedoresController : Controller
    {
        private IProveedoresRepository proveedoresRepository;

        public ProveedoresController()
        {
            this.proveedoresRepository = new ProveedoresRepository(new Contexto());
        }
        
        //Método para mostrar proveedores
        public ActionResult MostrarProveedores()
        {
            var proveedores = proveedoresRepository.listaProveedores();
            return View(proveedores);
        }
    }
}