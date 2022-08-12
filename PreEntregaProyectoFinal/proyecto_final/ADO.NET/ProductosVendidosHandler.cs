using Proyecto_final.modelos;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto_final.ADO.NET
{
    public class ProductosVendidosHandler : DbHandler
    {
        public List<ProductoVendido> DevolverProductosVendidos(int idVenta)
        {

            List<ProductoVendido> listaVentas = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta = @idVenta", sqlConnection))
                {

                    var parametro = new SqlParameter();
                    parametro.ParameterName = "idVenta";
                    parametro.SqlDbType = SqlDbType.Int;
                    parametro.Value = idVenta;
                    sqlCommand.Parameters.Add(parametro);

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido ProductoVenta = new ProductoVendido();

                                ProductoVenta.id = Convert.ToInt32(dataReader["Id"]);
                                ProductoVenta.stock = Convert.ToInt32(dataReader["Stock"]);
                                ProductoVenta.idProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                ProductoVenta.idVenta = Convert.ToInt32(dataReader["IdVenta"]);


                                listaVentas.Add(ProductoVenta);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ese usuario no Realizo ninguna venta o no existe");
                        }
                    }

                    sqlConnection.Close();

                }

            }
            
            return listaVentas;

        }
    }
}
