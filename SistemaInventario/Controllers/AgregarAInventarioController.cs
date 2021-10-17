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
    [Admin]
    public class AgregarAInventarioController : Controller
    {

        Contexto contexto = new Contexto();

        public ActionResult RealizarCompras(int[] IdAutos, int[] Cantidades, double[] precios)
        {
            var compra = new tabCompras();       
            contexto.Entry(compra).State = EntityState.Added;
            //Seleccionar inventariodondela cantidad sea mayor a cero
            int i = 0;
            var listaiInventario = contexto.tabInventario.ToList();
            foreach(var listado in listaiInventario)
            {
                if(IdAutos[i] == listado.fk_auto && Cantidades[i] > 0)
                {
                    precios[i] = Math.Round(precios[i], 2);
                    var model = new DAL.Models.tabDetalleCompras();
                    model.fk_auto = listado.fk_auto;
                    model.marcaModelo = listado.MarcaAuto + " " + listado.ModeloAuto;
                    model.cantidad = Cantidades[i];
                    model.precioCompra = precios[i];
                    model.subTotal = Cantidades[i] * precios[i];
                    model.idCompra = compra.IdCompra;
                    contexto.Entry(model).State = EntityState.Added;
                    contexto.SaveChanges();
                   
                }
                i++;
            }
                  
            return RedirectToAction("MostrarCompras", "Compras");
        }

    }
}