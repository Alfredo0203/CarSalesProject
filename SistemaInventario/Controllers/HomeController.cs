using DAL.Seguridad;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DAL.Encriptado;
using BAL.Services;
using BAL.IServices;
using System.Text.RegularExpressions;

namespace SistemaInventario.Controllers
{

    public class HomeController : Controller
    {
        IClientesRepositoty clientesRepository;
        public HomeController()
        {
            this.clientesRepository = new ClientesRepository(new Contexto());
        }
        Contexto contexto = new Contexto();
        //Crear redirección para login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string correo, string passw)
        {
            if (ModelState.IsValid)
            {
                var pass = EncriptarPassword.EncriptarPass(passw);
                var User = contexto.tabUsuarios.FirstOrDefault(x => x.correo.Equals(correo) &&
                            x.pass.Equals(pass));
                var User2 = contexto.tabClientes.FirstOrDefault(x => x.correo.Equals(correo) &&
                            x.pass.Equals(pass));
                if (User != null)
                {

                    Session["UserId"] = User.idUsuario.ToString();
                    Session["NombreUsuario"] = User.nombre + " " + User.apellido;
                    Session["UserRol"] = User.rol.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else if (User2 != null)
                {
                    Session["UserId"] = User2.idCliente.ToString();
                    Session["NombreUsuario"] = User2.nombre;
                    Session["UserRol"] = User2.rol.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "Usuario o contraseñas incorrectos");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrarse()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(tabClientes cliente)
        {
            Regex regex = new Regex("^\\d{8}$");
            if(!regex.IsMatch(cliente.telefono)) ModelState.AddModelError("Numero", "Numero incorrecto");
            if (clientesRepository.ExisteDato(cliente.correo)) ModelState.AddModelError("CorreoExiste", "Este correo ya está en uso");
            //CAPTURA DE CREDENCIALES PARA INGRESAR AUTOMÁTICAMENTE AL SISTEMA DESPUES DEL REGISTRO
            if (ModelState.IsValid)
            {
                string correo = cliente.correo;
                string password = cliente.pass;
                cliente.pass = EncriptarPassword.EncriptarPass(cliente.pass);
                cliente.ConfirmarPass = EncriptarPassword.EncriptarPass(cliente.ConfirmarPass);

                clientesRepository.AgregarClientes(cliente);
                TempData["Message"] = cliente.nombre + ": Bienvenido, gracias por registrarte";
                return Login(correo, password);
            }
            else
            {
                return View("Registrarse");
            }
        }
    }
}