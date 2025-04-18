using System;
using System.Collections.Generic;
using SistemaGestionEmpleados_Consola;

namespace SistemaEmpleados
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Agregar empleado");
                Console.WriteLine("2. Ver empleados");
                Console.WriteLine("3. Eliminar empleado");
                Console.WriteLine("4. Salir");

                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado();
                        break;
                    case "2":
                        MostrarEmpleados();
                        break;
                    case "3":
                        EliminarEmpleado();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            }
        }

        static void MostrarEmpleados()
        {
            List<Empleado> empleados = EmpleadoService.ObtenerEmpleados();

            Console.WriteLine("\n--- LISTADO DE EMPLEADOS ---");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (var emp in empleados)
                {
                    Console.WriteLine($"ID: {emp.Id} | {emp.Nombre} {emp.Apellido} - {emp.Cargo} - Sueldo: {emp.Sueldo}");
                }
            }
        }

        static void AgregarEmpleado()
        {
            Empleado emp = new Empleado();

            Console.Write("Nombre: ");
            emp.Nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            emp.Apellido = Console.ReadLine();

            Console.Write("Cargo: ");
            emp.Cargo = Console.ReadLine();

            Console.Write("Sueldo: ");
            emp.Sueldo = Convert.ToDecimal(Console.ReadLine());

            EmpleadoService.AgregarEmpleado(emp);
        }

        static void EliminarEmpleado()
        {
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                EmpleadoService.EliminarEmpleado(id);
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}