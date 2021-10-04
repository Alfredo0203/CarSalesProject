using BAL.IServices;
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
    [Cliente]
    public class CarritoController : Controller
    {
        private readonly ICarritoRepository carritoRepository;
        private Contexto contexto = new Contexto();

        public CarritoController()
        {
            this.carritoRepository = new CarritoRepository(new Contexto());
        }

        // GET: Carrito
        public ActionResult MostrarCarrito()
        {
            //Manda la lista de inventario a la vista y  también la lista de producto de cliente por medio ViewBag(Para comparar y mostrar)
            try
            {
                int idCliente = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString()); //Convierte el id del cliente en sesión a entero
                var autosEnCarrito = contexto.Carrito.Where(x => x.IdCliente == idCliente).ToList(); // Almacena listado de productos en carrito de acuerdo alcliente
                var inventario = contexto.tabInventario.ToList();
                ViewBag.ListaCarrito = autosEnCarrito;
                return View(inventario);
            }
            catch (Exception)
            {
                return View();
            }

        }

        // Agregar Al Carrito

        public JsonResult SeleccionarProducto(int id = 0)
        {
            bool success = false;
            if (id > 0)
            {
                try
                {  //Crea un objeto de la entidad carrito
                    Carrito elemento = new Carrito();
                    //Obtiene y convierte el id Del Cliente en sesión
                    int clienteInt = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString());
                    //Asignación de valores al objeto
                    elemento.FkAuto = id;
                    elemento.Cantidad = 1;
                    elemento.IdCliente = contexto.tabClientes.FirstOrDefault(x => x.idCliente == clienteInt).idCliente;
                    // Llama la función para agregar y le envía el objeto comoparámetro
                    carritoRepository.AgregarAlCarrito(elemento);
                    success = true;
                }
                catch (Exception) { }
            }
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
                    // Obtiene el Id del cliente y lo convierte a entero
                    int clienteInt = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString());
                    // LLama el método para eliminary le pasa el id de auto y id del cliente para eliminar solo los que le pertenecen a este
                    carritoRepository.SacarDelCarrito(id, clienteInt);
                    success = true;
                }
                catch (Exception) { }
            }
            return Json(success, JsonRequestBehavior.AllowGet);
        }
        // Método realizar la compra del cliente
        public JsonResult Vender()
        {
            bool CompraFinalizada = false;
            try
            {
                string rolClienteString = Session["UserRol"].ToString(); // ------------------------------------------------------------------------------------------ Almacena nombre del rol en una variable
                int clienteInt = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString()); // ------------------------------------------------------------- Convirte a entero y almacena id delcliente
                var miProductoEnCarrito = contexto.Carrito.Where(x => x.IdCliente == clienteInt).ToList(); // -------------------------------------------------------- Obtiene listado de producto en carrito del cliente logeado
                var IdCliente = contexto.tabClientes.FirstOrDefault(x => x.idCliente == clienteInt && rolClienteString.Equals("cliente")).idCliente; // -------------- Obtiene el id delcliente logeado
                var nuevaVenta = new tabVentas(); // ------------------------------------------------------------------------------------------------------------------------ Crea nuevo objeto de la tabla ventas

                nuevaVenta.FkCliente = IdCliente; // ------------------------------------------------------------------------------------------------------------------------
                contexto.Entry(nuevaVenta).State = EntityState.Added; // ----------------------------------------------------------------------------------------------------
                foreach (var miProducto in miProductoEnCarrito)
                {
                    var AutoEnInventario = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == miProducto.FkAuto); // -------------------------------------------- De la tabla inventario Obtiene los datos del producto que tenía el cliente en carrito
                    if (AutoEnInventario.existenciaProducto == 0 && AutoEnInventario.fk_auto == miProducto.FkAuto) continue; // -------------------------------------- Omite (y salta la iteracción) en caso que no haya producto delque elcliente tiene en carrito
                    var Precio = contexto.tabInventario.FirstOrDefault(x => x.idInventario == miProducto.FkAuto).precio; // ----------------------------------------- Obtiene el precio del auto de la tabla invntario
                    var model = new DAL.Models.tabDetalleVentas(); //------------------------------------------------------------------------------------------------- Se crea objeto para guardar los pedidos del cliente como ventas             


                    //ASIGNACÍÓN DE LOS DATOS AL OBJETO DE LA TABLA DETALLEVENTAS
                    model.fk_auto = miProducto.FkAuto;
                    model.cantidad = miProducto.Cantidad;
                    model.precio = Precio;
                    model.subTotal = miProducto.Cantidad * Precio;
                    model.idVenta = nuevaVenta.IdVenta;
                    var idAuto = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == miProducto.FkAuto).fk_auto; // ---------------------------------------------- OBTIENE EL ID DEL AUTO QUE EL CLIENTE TENIA EN CARRITO
                    model.subTotal = miProducto.Cantidad * Precio;
                    nuevaVenta.Total += model.subTotal;

                    //Se saca el producto del carrito por medio del id del cliente y el id de auto
                    carritoRepository.SacarDelCarrito(idAuto, clienteInt);
                    //Se llama la función para guardar los datos del objeto de detalleventas
                    contexto.Entry(model).State = EntityState.Added;
                    //Se guardan los cambios en la base de datos
                    contexto.SaveChanges();
                }
                CompraFinalizada = true;
            } // Finaliza el try
            catch (Exception) { }
            return Json(CompraFinalizada, JsonRequestBehavior.AllowGet);
        }
        // Recibe el id del auto y la cantidad 
        public JsonResult EditarCantidad(int id, int cantidad)
        {
            bool success = false;
            try
            {
                // Obtiene el id del cliente logeado y lo convierte a entero
                int clienteId = InventarioRepository.ConvertirAEntero(Session["UserId"].ToString());
                // LLama elmétodo actualizar y le envía elid del auto, el nombre del cliente (para encontrar el correcto porque pueden haber varios con el mismo id)
                carritoRepository.ActualizarCantidad(id, clienteId, cantidad);
                success = true;
            }
            catch (Exception) { }

            return Json(success, JsonRequestBehavior.AllowGet);
        }





    }
}