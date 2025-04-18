using System;
using Microsoft.Data.SqlClient;

namespace SistemaGestionEmpleados_Consola
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            var connectionString = "Server=GABRIEL\\SQLEXPRESS;Database=SistemaGestionEmpleadosDB;Trusted_Connection=True;TrustServerCertificate=True;";
            SqlConnection conexion = new SqlConnection(connectionString);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return null;
            }
        }
    }
}