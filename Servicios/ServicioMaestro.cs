using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioMaestro
    {
        IRepositorioMaestro repositorio;
        public ServicioMaestro()
        {
            repositorio = new RepositorioMaestro();
        }

        public List<Sexo> ObtenerSexos()
        {
            return repositorio.ObtenerSexos();
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            return repositorio.ObtenerTiposDocumento();
        }

        public List<Antecedente> ObtenerAntecedentes()
        {
            return repositorio.ObtenerAntecedentes();
        }
    }
}
