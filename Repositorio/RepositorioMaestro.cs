using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioMaestro : IRepositorioMaestro
    {
        public List<Sexo> ObtenerSexos()
        {
            List<Sexo> sexos = new List<Sexo>();
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DigiSalud"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT IdSexo, Nombre FROM sexo ORDER by Nombre";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sexos.Add(new Sexo() { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                }
            }

            return sexos;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DigiSalud"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT IdTipoDocumento, Nombre FROM TiposDocumento ORDER by Nombre";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposDocumento.Add(new TipoDocumento() { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                }
            }

            return tiposDocumento;
        }

        public List<Antecedente> ObtenerAntecedentes()
        {
            List<Antecedente> antecedentes = new List<Antecedente>();
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DigiSalud"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT IdAntecedente, Nombre FROM Antecedentes ORDER by Nombre";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        antecedentes.Add(new Antecedente() { Id = reader.GetInt32(0), Nombre = reader.GetString(1) });
                    }
                }
            }

            return antecedentes;
        }
    }
}

