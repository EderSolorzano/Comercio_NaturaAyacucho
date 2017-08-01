using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Natura_Ayacucho.Controllers
{
    
    public class HomeController : Controller
    {
        private Models.TiendaEntities1 bd = new Models.TiendaEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string id="")
        {
            //logica de acceso para bd
            var productos = bd.Producto
                .Where(x => x.Denominacion.Contains(id))// x.Descripcion.Contains(id))
               .Take(20)
                .ToList();
            ViewBag.clave = id;
            return View(productos);
            //tomar los 20 primeros productos que cumplan la condicion
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Boletin()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult Terminos()
        {
            return View();
        }

        public ActionResult Resumen()
        {
            return View();
        }
    }
}