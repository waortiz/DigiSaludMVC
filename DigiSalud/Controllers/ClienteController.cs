using DigiSalud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiSalud.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Ingresar()
        {
            var tiposDocumento = new List<SelectListItem>();
            tiposDocumento.Add(new SelectListItem()
            {
                Text = "Cédula de Ciudadanía",
                Value = "1"
            });
            tiposDocumento.Add(new SelectListItem()
            {
                Text = "Tarjeta de Identidad",
                Value = "2"
            });
            tiposDocumento.Add(new SelectListItem()
            {
                Text = "Tarjeta de Extranjería",
                Value = "3"
            });
            ViewBag.TiposDocumento = tiposDocumento;

            return View(new Cliente() { PrimerNombre="Pepito" });
        }

        [HttpPost]
        public ActionResult Ingresar(Cliente cliente)
        {
            return View();
        }
    }
}