using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public void IngresarCliente(Entidades.Cliente cliente)
        {
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DigiSalud"].ConnectionString))
            {
                conexion.Open();
                SqlTransaction tran = conexion.BeginTransaction();
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;
                    comando.Transaction = tran;
                    comando.CommandText = "IngresarCliente";
                    var parameter = new SqlParameter("@IdCliente", SqlDbType.BigInt);
                    parameter.Direction = ParameterDirection.Output;

                    comando.Parameters.Add(parameter);
                    comando.Parameters.Add("@PrimerNombre", SqlDbType.VarChar, 50).Value = cliente.PrimerNombre;
                    comando.Parameters.Add("@SegundoNombre", SqlDbType.VarChar, 50).Value = cliente.SegundoNombre;
                    comando.Parameters.Add("@PrimerApellido", SqlDbType.VarChar, 50).Value = cliente.PrimerApellido;
                    comando.Parameters.Add("@SegundoApellido", SqlDbType.VarChar, 50).Value = cliente.SegundoApellido;
                    comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 50).Value = cliente.NumeroDocumento;
                    comando.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = cliente.FechaNacimiento;
                    comando.Parameters.Add("@IdSexo", SqlDbType.SmallInt).Value = cliente.Sexo.Id;
                    comando.Parameters.Add("@IdTipoDocumento", SqlDbType.SmallInt).Value = cliente.TipoDocumento.Id;
                    comando.Parameters.Add("@Cotizante", SqlDbType.SmallInt).Value = cliente.Cotizante;
                    comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar, 5000).Value = cliente.Observaciones;

                    comando.ExecuteNonQuery();

                    if (cliente.Antecedentes != null)
                    {
                        var idCliente = comando.Parameters["@IdCliente"].Value;
                        foreach (int antecedente in cliente.Antecedentes)
                        {
                            SqlCommand comandoAntecedente = new SqlCommand();
                            comandoAntecedente.CommandType = CommandType.StoredProcedure;
                            comandoAntecedente.Connection = conexion;
                            comandoAntecedente.Transaction = tran;
                            comandoAntecedente.CommandText = "IngresarAntecedente";

                            comandoAntecedente.Parameters.Add("@IdCliente", SqlDbType.BigInt).Value = idCliente;
                            comandoAntecedente.Parameters.Add("@IdAntecedente", SqlDbType.Int).Value = antecedente;

                            comandoAntecedente.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DigiSalud"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "SELECT cli.IdCliente, cli.PrimerNombre, cli.SegundoNombre, cli.PrimerApellido, cli.SegundoApellido, cli.NumeroDocumento, cli.IdTipoDocumento, td.Nombre NombreTipoDocumento, cli.FechaNacimiento FROM Clientes cli INNER JOIN TiposDocumento td on td.IdTipoDocumento = cli.IdTipoDocumento ORDER by cli.NumeroDocumento";

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Cliente cliente= new Entidades.Cliente();
                        cliente.IdCliente = Convert.ToInt64(reader["IdCliente"]);
                        cliente.PrimerNombre = reader["PrimerNombre"].ToString();
                        cliente.SegundoNombre = reader["SegundoNombre"].ToString();
                        cliente.PrimerApellido = reader["PrimerApellido"].ToString();
                        cliente.SegundoApellido = reader["SegundoApellido"].ToString();
                        cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                        cliente.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        cliente.TipoDocumento = new Entidades.TipoDocumento()
                        {
                            Id = Convert.ToInt32(reader["IdTipoDocumento"]),
                            Nombre = reader["NombreTipoDocumento"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }
    }
}
