using DigiSalud.Models;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiSalud.Controllers
{
    public class ClienteController : Controller
    {
        ServicioCliente servicioCliente = new ServicioCliente();
        ServicioMaestro servicioMaestro = new ServicioMaestro();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Ingresar()
        {
            ViewBag.TiposDocumento = ObtenerTiposDocumento();
            ViewBag.Antecedentes = ObtenerAntecedentes();

            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(Cliente cliente)
        {
            Entidades.Cliente nuevoCliente = new Entidades.Cliente()
            {
                Antecedentes = cliente.Antecedentes,
                Cotizante = cliente.Cotizante,
                FechaNacimiento = cliente.FechaNacimiento,
                NumeroDocumento = cliente.NumeroDocumento,
                PrimerApellido = cliente.PrimerApellido,
                PrimerNombre = cliente.PrimerNombre,
                SegundoApellido = cliente.SegundoApellido,
                SegundoNombre = cliente.SegundoNombre,
                Sexo = new Entidades.Sexo() { Id = cliente.Sexo },
                TipoDocumento = new Entidades.TipoDocumento() {  Id = cliente.TipoDocumento},
                Observaciones = cliente.Observaciones
            };

            servicioCliente.IngresarCliente(nuevoCliente);

            ViewBag.TiposDocumento = ObtenerTiposDocumento();
            ViewBag.Antecedentes = ObtenerAntecedentes();

            return View();
        }


        private List<SelectListItem> ObtenerTiposDocumento()
        {
            var tiposDocumentoActuales = servicioMaestro.ObtenerTiposDocumento();
            var tiposDocumento = new List<SelectListItem>();
            foreach (var tipo in tiposDocumentoActuales)
            {
                tiposDocumento.Add(new SelectListItem()
                {
                    Text = tipo.Nombre,
                    Value = tipo.Id.ToString()
                });
            }

            return tiposDocumento;
        }

        private List<SelectListItem> ObtenerAntecedentes()
        {
            var antecedentesActuales = servicioMaestro.ObtenerAntecedentes();
            var antecedentes = new List<SelectListItem>();
            foreach (var tipo in antecedentesActuales)
            {
                antecedentes.Add(new SelectListItem()
                {
                    Text = tipo.Nombre,
                    Value = tipo.Id.ToString()
                });
            }

            return antecedentes;
        }
    }
}