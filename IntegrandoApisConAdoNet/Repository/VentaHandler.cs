using System.Data.SqlClient;
using System.Data;
using IntegrandoApisConAdoNet.Model;

namespace IntegrandoApisConAdoNet.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString = "Server=PCCESAR;DataBase=SistemaGestion;Trusted_Connection=True";

        //Traer Ventas
        public static List<Venta> GetVentas()
        {

            List<Venta> ventas = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                venta.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                ventas.Add(venta);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return ventas;
            
        }


        //Cargar Venta
        public static bool CargarVenta(Venta venta)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] " +
                    "(Comentarios,IdUsuario) VALUES " +
                    "(@comentariosParameter, @idUsuarioParameter);";

                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };
                SqlParameter idUsuarioParameter = new SqlParameter("idUsuarioParameter", SqlDbType.BigInt) { Value = venta.IdUsuario };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(comentariosParameter);
                    sqlCommand.Parameters.Add(idUsuarioParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }

                }
                sqlConnection.Close();

            }

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                
                string queryInsert2 = "UPDATE Producto SET Stock = Stock -1 WHERE Descripciones = @comentariosParameter";

                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert2, sqlConnection))
                {
                    sqlCommand.Parameters.Add(comentariosParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                }

                sqlConnection.Close();
            }

            return resultado;
        }

    }
}
