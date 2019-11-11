using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiSalud.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult Listado()
        {
            ServicioCliente servicio = new ServicioCliente();
            List<Cliente> clientes = servicio.OntenerClientes();

            return View(clientes);
        }

        public ActionResult Grafico()
        {
            ServicioCliente servicio = new ServicioCliente();
            List<Cliente> clientes = servicio.OntenerClientes();

            var deportistasPorAnyo = clientes.GroupBy(p => p.FechaNacimiento.Year).Select(p => new { Year = p.Key, Cantidad = p.Count() });
            var datosGrafico = "[";
            if (deportistasPorAnyo.Count() > 0)
            {
                foreach (var valor in deportistasPorAnyo)
                {
                    datosGrafico += "['" + valor.Year + "', " + valor.Cantidad + "],";
                }
                datosGrafico = datosGrafico.Substring(0, datosGrafico.Length - 1);
                datosGrafico += "]";
            }
            else
            {
                datosGrafico = "[]";
            }

            ViewBag.DatosGrafico = datosGrafico;
            return View();
        }
    }
}
