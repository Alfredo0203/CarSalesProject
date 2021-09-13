using DAL.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DAL.Encriptado
{
    public class Permisos : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var UserId = HttpContext.Current.Session["UserId"];
            var id_string = "0";

            if (UserId != null)
            {
                id_string = UserId.ToString();
            }

            if (!PermisosPorRol.IsAdmin(int.Parse(id_string)))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Error"
                    }
                    ));
            }
            
        }
    }

    public class PermisosPorRol
    {
        public static bool IsAdmin(int UserId)
        {
            if (UserId <= 0)
            {
                return false;
            }

            using (var context = new Contexto())
            {
                var User = context.tabUsuarios.FirstOrDefault(x => x.idUsuario == UserId);
                return User.rol == Rol.admin ? true : false;
            }
        }
    }

}