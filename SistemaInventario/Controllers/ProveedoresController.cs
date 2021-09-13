using BAL.IServices;
using BAL.Services;
using DAL.Encriptado;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class ProveedoresController : Controller
    {
        private IProveedoresRepository proveedoresRepository;

        //Constructor
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
        
        //EDITAR PROVEEDORES
        public ActionResult EditOrAddProveedores(int idProveedor = 0)
        {
            var proveedores = new tabProveedores();

            if (idProveedor > 0)
            {
                proveedores = proveedoresRepository.ObtenerProveedorPorId(idProveedor);
            }
            return View(proveedores);
        }

        [HttpPost]
        //AGREGAR PROVEEDOR
        public ActionResult EditOrAddProveedores(tabProveedores proveedores)
        {
            if (ModelState.IsValid)
            {
                var creado = proveedoresRepository.CreateOrAddProveedores(proveedores);

                if (creado)
                {
                    return RedirectToAction("MostrarProveedores");
                }
            }
            return View(proveedores);
        }

        //ELIMINAR PROVEEDOR
        public ActionResult EliminarProveedor(int idProv)
        {
            proveedoresRepository.EliminarProveedor(idProv);
            return RedirectToAction("MostrarProveedores");
        }
    }
}