using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioCliente
    {
        IRepositorioCliente repositorio;
        public ServicioCliente()
        {
            repositorio = new RepositorioCliente();
        }

        public void IngresarCliente(Cliente Cliente)
        {
            repositorio.IngresarCliente(Cliente);
        }

        public List<Cliente> OntenerClientes()
        {
            return repositorio.ObtenerClientes();
        }
    }
}
