using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SistemaGestionEmpleados_Consola
{
    public class EmpleadoService
    {
        public static void AgregarEmpleado(Empleado emp)
        {
            using SqlConnection conn = Conexion.ObtenerConexion();
            if (conn == null) return;

            string query = "INSERT INTO Empleados (Nombre, Apellido, Cargo, Sueldo) VALUES (@Nombre, @Apellido, @Cargo, @Sueldo)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", emp.Apellido);
            cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
            cmd.Parameters.AddWithValue("@Sueldo", emp.Sueldo);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Empleado agregado correctamente.");
        }

        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                if (conn == null) return lista;

                string query = "SELECT * FROM Empleados";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Empleado emp = new Empleado
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        Cargo = reader["Cargo"].ToString(),
                        Sueldo = Convert.ToDecimal(reader["Sueldo"])
                    };
                    lista.Add(emp);
                }

                reader.Close();
            }

            return lista;
        }
    

    public static void EliminarEmpleado(int id)
        {
            using SqlConnection conn = Conexion.ObtenerConexion();
            if (conn == null) return;

            string query = "DELETE FROM Empleados WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            int filasAfectadas = cmd.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                Console.WriteLine("Empleado eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un empleado con ese ID.");
            }
        }
    }
}

