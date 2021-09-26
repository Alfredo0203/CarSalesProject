using BAL.AgregarAInventario;
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
    public class AgregarAInventarioController : Controller
    {

        Contexto contexto = new Contexto();
        public ActionResult SeleccionarProducto(int id)
        {
            int Cantidad = 1;
            AgregarAInventario auto = new AgregarAInventario();
            var Marca = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == id).tabAutos.NombreMarca;
            var Modelo = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == id).tabAutos.modelo;
            var Precio = contexto.tabInventario.FirstOrDefault(x => x.idInventario == id).precio;
            var Total = Cantidad * Precio;
            AgregarAInventario.TotalAPagar += Total;
            bool existe = (from a in AgregarAInventario.listaAutosAComprar where a.Id == id select a).Any();
            if (existe == false)
            {
                auto.AgregarparaComprar(id, Marca, Modelo, Cantidad, Precio, Total);

            }
            else
            {

                foreach (var a in AgregarAInventario.listaAutosAComprar.Where(a => a.Id == id))
                {

                    a.Cantidad = a.Cantidad + 1;
                    a.SubTotal += Precio * Cantidad;
                    break;

                }

            }

            return RedirectToAction("AgregarOEditarCompras","Compras");
        }

        //QUITAR ELEMENTOS DELCARRITO
        public ActionResult EliminarElementoDeLaLista(int id = 0)
        {
            var precio = AgregarAInventario.listaAutosAComprar.FirstOrDefault(x => x.Id == id).PrecioCompra;
            var cantidad = AgregarAInventario.listaAutosAComprar.FirstOrDefault(x => x.Id == id).Cantidad;
            AgregarAInventario.TotalAPagar -= (precio * cantidad);
            AgregarAInventario.listaAutosAComprar.RemoveAll(x => x.Id == id);
            return RedirectToAction("MostrarCompras", "Compras");
        }


        public ActionResult RealizarCompras()
        {
            var compra = new tabCompras();
            compra.Total = AgregarAInventario.TotalAPagar;

            compra.CodigoFactura = compra.CodigoFactura > 0 ? compra.CodigoFactura = contexto.tabCompras.OrderByDescending(x => x.CodigoFactura).First().CodigoFactura + 1 : compra.CodigoFactura = 1;
            contexto.Entry(compra).State = EntityState.Added;

            foreach (var p in AgregarAInventario.listaAutosAComprar)
            {

                var model = new DAL.Models.tabDetalleCompras();
                model.fk_auto= p.Id;
                model.marcaModelo = p.Marca + " " + p.Modelo;
                model.cantidad = p.Cantidad;
                model.precioCompra= p.PrecioCompra;
                model.subTotal = p.SubTotal;
                model.idCompra = compra.IdCompra;
                contexto.Entry(model).State = EntityState.Added;
                contexto.SaveChanges();

            }

            AgregarAInventario.listaAutosAComprar.RemoveRange(0, AgregarAInventario.listaAutosAComprar.Count());
            AgregarAInventario.TotalAPagar = 0;
            return RedirectToAction("MostrarCompras", "Compras");
        }

    }
}