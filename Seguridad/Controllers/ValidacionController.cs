using Seguridad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Seguridad.Controllers
{
    public class ValidacionController : Controller
    {
        // GET: Validacion
        public ActionResult Acceso()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String usuario, String pass)
        {
            ModeloUsuarios modelo = new ModeloUsuarios();
            USUARIOS user = modelo.ExisteUsuario(usuario, pass);
            if (user != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.userName, DateTime.Now, DateTime.Now.AddHours(1), true, "", FormsAuthentication.FormsCookiePath);
                String datosCifrados = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("cookieUsuario", datosCifrados);
                Response.Cookies.Add(cookie);                
                return RedirectToAction("Acceso", "Validacion");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Contraseña incorrecta!";
            }
            return View();
        }
    }
}