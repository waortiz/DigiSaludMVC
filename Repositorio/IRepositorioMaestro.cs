using Entidades;
using System.Collections.Generic;

namespace Repositorio
{
    public interface IRepositorioMaestro
    {
        List<Sexo> ObtenerSexos();
        List<TipoDocumento> ObtenerTiposDocumento();
        List<Antecedente> ObtenerAntecedentes();
    }
}