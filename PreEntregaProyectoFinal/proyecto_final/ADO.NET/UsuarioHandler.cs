using Proyecto_final.modelos;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_final.ADO.NET
{
    public class UsuarioHandler : DbHandler
    {
        
        public List<Usuario> ObtenerUsuario(string nombreUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE Nombre = @NombreUsu", sqlConnection))
                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "NombreUsu";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametro);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Contrasenia = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                usuarios.Add(usuario);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("No existe un usuario con el nombre ingresado");
                        }
                    }

                    sqlConnection.Close();

                }
            }

            return usuarios;
        }
    }
}
