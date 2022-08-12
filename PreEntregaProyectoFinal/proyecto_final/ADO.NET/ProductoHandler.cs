
using Proyecto_final.modelos;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_final
{
    public class ProductoHandler : DbHandler
    {

        
        public List<Producto> DevolverProductosConIdusuario(int idUsuario)
        {

            List<Producto> listaProductos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", sqlConnection))
                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idUsuario";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = idUsuario;
                    sqlCommand.Parameters.Add(parametro);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripcion = dataReader["Descripciones"].ToString();
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt64(dataReader["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                listaProductos.Add(producto);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ese usuario no cargo ningun producto o no existe");
                        }
                    }

                    sqlConnection.Close();

                }

            }
            return listaProductos;

        }
    }
}