using System.Data.SqlClient;
using System.Data;
using IntegrandoApisConAdoNet.Model;

namespace IntegrandoApisConAdoNet.Repository
{
    public static class VentaHandler
    {
        public const string ConnectionString = "Server=PCCESAR;DataBase=SistemaGestion;Trusted_Connection=True";

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
            return resultado;
        }

    }
}
