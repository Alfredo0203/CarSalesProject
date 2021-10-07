using BAL.IServices;
using BAL.Services;
using DAL.Models;
using Rotativa;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        Contexto contexto = new Contexto();
        private IDetalleVentasRepository detalleVentasRepository;
        private IClientesRepositoty clienteRepository;
        private IDetalleVentasRepository ventasRepository;
        private IDetalleComprasRepository comprasRepository;

        // GET: Reportes
        public ReportesController()
        {
            this.detalleVentasRepository = new VentasRepository(new Contexto());
            this.clienteRepository = new ClientesRepository(new Contexto());
            this.ventasRepository = new VentasRepository(new Contexto());
            this.comprasRepository = new ComprasRepository(new Contexto());

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImprimirDetalleVentas()
        {
            var model = detalleVentasRepository.ListarDetalleVentas();
            ViewBag.Id = Session["UserId"].ToString();
            ViewBag.Ventas = contexto.tabVentas.ToList();

            return new ViewAsPdf("DetalleVenta", model)
            {
                PageSize = Rotativa.Options.Size.Letter,
                PageMargins = new Rotativa.Options.Margins(20, 10, 20, 10),
                FileName = "DetalleVenta.pdf"
            };
        }


        public ActionResult ImprimirDetalleCompras()
        {
                string IdCliente = Session["UserId"].ToString();
                string RolCliente = Session["UserRol"].ToString();
                var model = ventasRepository.ListarDetalleVentas();

                    ViewBag.MisCompras = contexto.tabVentas.ToList();
                    ViewBag.IdCliente = int.Parse(IdCliente);
                    ViewBag.NombreCliente = contexto.tabClientes.FirstOrDefault(x => x.idCliente.ToString() == IdCliente && RolCliente.Equals("cliente")).nombre;
                return new ViewAsPdf("DetalleCompras", model)
                {
                    PageSize = Rotativa.Options.Size.Letter,
                    PageMargins = new Rotativa.Options.Margins(20, 10, 20, 10),
                    FileName = "DetalleCompra.pdf"
                };
            }
        public ActionResult ImprimirDetalleComprasProveedor()
        {
                var listadoCompras = comprasRepository.ListarDetalleCompras();
                ViewBag.Compras = contexto.tabCompras.ToList();

            return new ViewAsPdf("DetalleComprasProveedor", listadoCompras)
            {
                PageSize = Rotativa.Options.Size.Letter,
                PageMargins = new Rotativa.Options.Margins(20, 10, 20, 10),
                FileName = "DetalleCompras.pdf"
            };
        }
    }
    
}
