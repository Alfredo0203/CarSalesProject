using BAL.IServices;
using DAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Seguridad;
using DAL.Encriptado;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class ClientesController : Controller
    {
        private IClientesRepositoty clienteRepository;
        private IDetalleVentasRepository ventasRepository;
        public ClientesController()
        {
            this.clienteRepository = new ClientesRepository(new Contexto());
            this.ventasRepository = new VentasRepository(new Contexto());
        }
        [Admin]
        public ActionResult MostrarClientes()
        {
            var clientes = clienteRepository.ListaClientes();

            return View(clientes);
        }

        //REDIRECCIÓN A LA VISTA CON EL OBJETO CLIENTE
        [Admin]
        public ActionResult AgregarOEditarClientes(int idCliente = 0)
        {
            var cliente = new tabClientes();

            if (idCliente > 0)
            {
                cliente = clienteRepository.ObtenerClientesPorID(idCliente);
            }

            return View(cliente);
        }
        // INSERCIÓN DE LOS DATOS
        [Admin]
        [HttpPost]
        public ActionResult AgregarOEditarClientes(tabClientes cliente)
        {

            if (ModelState.IsValid)
            {
                
                if (cliente.idCliente > 0)
                {
                    TempData["Message"] = "Datos de " + cliente.nombre + " actualizados";
                    clienteRepository.ActualizarClientes(cliente);

                }
                else
                {
                    clienteRepository.AgregarClientes(cliente);
                    TempData["Message"] = "Datos de agregados correctamente";
                }

                return RedirectToAction("MostrarClientes");
            }

            return View(cliente);
        }
        [Admin]
        public ActionResult EliminarClientes(int id, bool success = false)
        {
            if(id > 0 && success == true)
            { 
            TempData["Message"] = "Cliente con nombre" + clienteRepository.ObtenerClientesPorID(id).nombre + " eliminado correctamente";
            clienteRepository.EliminarCliente(id);
             }
            return RedirectToAction("MostrarClientes");
        }
        [Cliente]
        public ActionResult ComprasClientes()
        {
            try
            {
                string IdCliente = Session["UserId"].ToString();
                string RolCliente = Session["UserRol"].ToString();
                var model = ventasRepository.ListarDetalleVentas();
                using (Contexto db = new Contexto()) {
                    
                    ViewBag.MisCompras = db.tabVentas.ToList();
                    ViewBag.IdCliente = int.Parse(IdCliente);
                    ViewBag.NombreCliente = db.tabClientes.FirstOrDefault(x => x.idCliente.ToString() == IdCliente && RolCliente.Equals("cliente")).nombre;
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}