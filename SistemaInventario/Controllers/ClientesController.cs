using BAL.IServices;
using DAL.Models;
using BAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ClientesController : Controller
    {
        private IClientesRepositoty clienteRepository;

        public ClientesController()
        {
            this.clienteRepository = new ClientesRepository(new Contexto());
        }
        public ActionResult MostrarClientes()
        {
          var clientes  = clienteRepository.ListaClientes();

            return View(clientes);
        }
    }
}