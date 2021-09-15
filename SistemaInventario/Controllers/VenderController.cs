using BAL.ProductoParaVender;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class VenderController : Controller
    {

        Contexto contexto = new Contexto();
        public ActionResult SeleccionarProducto(int id)
        {
            int Cantidad = 1;
            AutosAVender auto = new AutosAVender();
            var Marca = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == id).MarcaAuto;
            var Modelo = contexto.tabInventario.FirstOrDefault(x => x.fk_auto == id).ModeloAuto;
            var Precio = contexto.tabInventario.FirstOrDefault(x => x.idInventario == id).precio;
            var Total = Cantidad * Precio;
            AutosAVender.TotalAPagar += Total;
            bool existe = (from a in AutosAVender.listaAutosAVender where a.Id == id select a).Any();
            if (existe == false)
            {
                auto.AgregarParaVender(id, Marca, Modelo, Cantidad, Precio, Total);

            }
            else
            {

                foreach (var a in AutosAVender.listaAutosAVender.Where(a => a.Id == id))
                {

                    a.Cantidad = a.Cantidad + 1;
                    a.SubTotal += Precio * Cantidad;

                    break;
                }



            }

            return RedirectToAction("MostrarInventario","Inventario");
        }

        //QUITAR ELEMENTOS DELCARRITO
        public ActionResult EliminarElementoDeLaLista(int id = 0)
        {
            var precio = AutosAVender.listaAutosAVender.FirstOrDefault(x => x.Id == id).Precio;
            var cantidad = AutosAVender.listaAutosAVender.FirstOrDefault(x => x.Id == id).Cantidad;
            AutosAVender.TotalAPagar -= (precio * cantidad);
            AutosAVender.listaAutosAVender.RemoveAll(x => x.Id == id);
            return RedirectToAction("MostrarInventario", "Inventario");
        }


        public ActionResult Vender()
        {
            var ven = new tabVentas();
            ven.Total = AutosAVender.TotalAPagar;

            ven.CodigoFactura = ven.CodigoFactura > 0 ? ven.CodigoFactura = contexto.tabVentas.OrderByDescending(x => x.CodigoFactura).First().CodigoFactura + 1 : ven.CodigoFactura = 1;
            contexto.Entry(ven).State = EntityState.Added;

            foreach (var p in AutosAVender.listaAutosAVender)
            {

                var model = new DAL.Models.tabDetalleVentas();

                model.fk_auto= p.Id;
                model.marcaModelo = p.Marca + " " + p.Modelo;
                model.cantidad = p.Cantidad;
                model.precio = p.Precio;
                model.subTotal = p.SubTotal;
                model.idVenta = ven.IdVenta;
                contexto.Entry(model).State = EntityState.Added;
                contexto.SaveChanges();

            }

            AutosAVender.listaAutosAVender.RemoveRange(0, AutosAVender.listaAutosAVender.Count());
            AutosAVender.TotalAPagar = 0;
            return RedirectToAction("MostrarInventario", "Inventario");
        }

    }
}