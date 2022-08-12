using Proyecto_final.modelos;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_final.ADO.NET
{
    public class LoginHandler : DbHandler
    {

        
        public List<Usuario> Login(string nombreUsuario, string contraseña)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE Nombre = @nombreUsuario AND Contraseña = @contraseña", sqlConnection))
                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "nombreUsuario";
                    parametro.SqlDbType = SqlDbType.VarChar;
                    parametro.Value = nombreUsuario;
                    sqlCommand.Parameters.Add(parametro);

                    var parametro2 = new SqlParameter();
                    parametro2.ParameterName = "contraseña";
                    parametro2.SqlDbType = SqlDbType.VarChar;
                    parametro2.Value = contraseña;
                    sqlCommand.Parameters.Add(parametro2);
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
                            Console.WriteLine();
                            Console.WriteLine("USUARIO O CONTRASEÑA INCORRECTOS");
                            Usuario usuario = new Usuario();

                            usuario.Id = 0;
                            usuario.Nombre = null;
                            usuario.Apellido = null;
                            usuario.NombreUsuario = null;
                            usuario.Contrasenia = null;
                            usuario.Mail = null;

                            usuarios.Add(usuario);

                        }
                    }

                    sqlConnection.Close();

                }
            }

            return usuarios;
        }
    }
}
