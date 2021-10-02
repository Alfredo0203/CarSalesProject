using BAL.IServices;
using BAL.ProductoParaVender;
using BAL.Services;
using DAL.Models;
using DAL.Seguridad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    [Permisos]
    public class CarritoController : Controller
    {
        private readonly ICarritoRepository carritoRepository;

        public CarritoController()
        {
            this.carritoRepository = new CarritoRepository(new Contexto());
        }

        // GET: Carrito
        public ActionResult MostrarCarrito()
        {
            try
            {
                int idCliente = ConvertirAEntero(Session["UserId"].ToString());
              var autosEnCarrito =  contexto.Carrito.Where(x => x.IdCliente == idCliente).ToList();
                var inventario = contexto.tabInventario.ToList();
                ViewBag.ListaCarrito = autosEnCarrito;
               
                return View(inventario);
            }
             catch(Exception)
            {
                return View();
            }
           
        }

        // Agregar Al Carrito
        Contexto contexto = new Contexto();
        public JsonResult SeleccionarProducto(int id)
        {
                    Carrito elemento = new Carrito();
                    bool success = false;
            try
            {
                int clienteInt = ConvertirAEntero(Session["UserId"].ToString());
                elemento.FkAuto = id;
                elemento.Cantidad = 1;
                elemento.IdCliente = contexto.tabClientes.FirstOrDefault(x => x.idCliente == clienteInt).idCliente;
                carritoRepository.AgregarAlCarrito(elemento);
                success = true;
            }
            catch (Exception) { }
            
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //QUITAR ELEMENTOS DELCARRITO
        public JsonResult EliminarElementoDeLaLista(int id = 0)
        {
            bool success = false;
            if (id > 0)
            {
                try
                {
                    carritoRepository.SacarDelCarrito(id);
                    success = true;
                }
                catch (Exception)
                {

                }
            }
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Vender()
        {
            Carrito carrito = new Carrito();
            string idClienteString = Session["UserRol"].ToString();
            int clienteInt = ConvertirAEntero(Session["UserId"].ToString());

            var misCompras = contexto.Carrito.ToList();
           
            var IdCliente = contexto.tabClientes.FirstOrDefault(x => x.idCliente == clienteInt && idClienteString.Equals("cliente")).idCliente;
            var ven = new tabVentas();
           
            ven.Total = AutosAVender.TotalAPagar;
            ven.FkCliente = IdCliente;
            contexto.Entry(ven).State = EntityState.Added;
            foreach (var c in misCompras)
            {
                if (c.IdCliente == c.IdCliente)
                {
                    var id = contexto.tabInventario.FirstOrDefault(x => x.idInventario == c.FkAuto).idInventario;
                    var model = new DAL.Models.tabDetalleVentas();
                    var Precio = contexto.tabInventario.FirstOrDefault(x => x.idInventario == c.FkAuto).precio;
                    model.fk_auto = c.FkAuto;
                    
                    model.cantidad = c.Cantidad;
                    model.precio = Precio;
                    model.subTotal = c.Cantidad * Precio;
                    model.idVenta = ven.IdVenta;
                    carritoRepository.SacarDelCarrito(id);
                    contexto.Entry(model).State = EntityState.Added;
                    contexto.SaveChanges();

                }
            }

           
            return RedirectToAction("MostrarCarrito","Carrito");
        }

        public int ConvertirAEntero(string id)
        {
            id = Session["UserId"].ToString();
            int clienteInt = int.Parse(id);
            return clienteInt;
        }
    }
}