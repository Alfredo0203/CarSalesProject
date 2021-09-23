using DAL.Seguridad;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaInventario.Controllers
{
    public class HomeController : Controller
    {
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
                //var pass = EncriptarPassword.EncriptarPass(passw);
                var User = contexto.tabUsuarios.FirstOrDefault(x => x.correo.Equals(correo) &&
                            x.pass.Equals(passw));
                if (User != null)
                {
                    Session["UserId"] = User.idUsuario.ToString();
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
            return RedirectToAction("Login");
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}