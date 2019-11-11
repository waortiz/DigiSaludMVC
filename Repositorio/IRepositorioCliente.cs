using System.Collections.Generic;
using Entidades;

namespace Repositorio
{
    public interface IRepositorioCliente
    {
        void IngresarCliente(Entidades.Cliente Cliente);
        List<Cliente> ObtenerClientes();
    }
}