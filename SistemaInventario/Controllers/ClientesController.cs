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
        
        public ActionResult MostrarClientes()
        {
            var clientes = clienteRepository.ListaClientes();
            if (Session["UserRol"].Equals("cliente"))
            {
                using (Contexto con = new Contexto())
                {
                    int clienteInt = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString());
                    var MisDatos = con.tabClientes.Where(x => x.idCliente == clienteInt).ToList();
                    ViewBag.MiPerfil = MisDatos;
                }

            }
            return View(clientes);
        }

        //REDIRECCIÓN A LA VISTA CON EL OBJETO CLIENTE
        [Cliente]
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
        [Cliente]
        [HttpPost]
        public ActionResult AgregarOEditarClientes(tabClientes cliente)
        {
           cliente.pass = EncriptarPassword.EncriptarPass(cliente.pass);
           cliente.ConfirmarPass= EncriptarPassword.EncriptarPass(cliente.ConfirmarPass);
            if (ModelState.IsValid)
            {
                
                if (cliente.idCliente > 0)
                {

                    TempData["Message"] = "Datos actualizados";
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
        [Cliente]
        public ActionResult EliminarClientes(int id, bool success = false)
        {
            if (id > 0 && success == true)
            {
                var contexto = new Contexto();
                tabClientes cliente = new tabClientes();
                cliente = clienteRepository.ObtenerClientesPorID(id);

                if (!contexto.tabVentas.Any(x => x.FkCliente == id))
                {
                    TempData["Message"] = "Cliente con nombre" + clienteRepository.ObtenerClientesPorID(id).nombre + " eliminado correctamente";
                    clienteRepository.EliminarCliente(id);
                }
                else
                {
                    cliente.isActivo = false;
                    cliente.ConfirmarPass = cliente.pass;
                    clienteRepository.ActualizarClientes(cliente);
                    return RedirectToAction("LogOut", "Home");

                }
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