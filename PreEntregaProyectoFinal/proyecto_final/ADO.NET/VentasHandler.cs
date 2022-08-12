using Proyecto_final.modelos;
using System.Data.SqlClient;
using System.Data;

namespace Proyecto_final.ADO.NET
{
    
    public class VentasHandler : DbHandler
    {
        public List<Venta> DevolverProductosVendidos(int idUsuario)
        {

            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @idUsuario", sqlConnection))
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
                                Venta productosVendidos = new Venta();

                                productosVendidos.id = Convert.ToInt32(dataReader["Id"]);
                                productosVendidos.comentarios = dataReader["Comentarios"].ToString();
                                productosVendidos.idUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                ventas.Add(productosVendidos);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ese usuario no tiene niguna venta asignada o no existe");
                        }
                    }

                    sqlConnection.Close();

                }

            }

            return ventas;

        }

    }
}
