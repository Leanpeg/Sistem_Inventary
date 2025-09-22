

 
 
using System;
using System.Collections.Generic;

namespace SistemaInventario
{
    class Program
    {
        // Diccionario global para el inventario (justificado como recurso central)
        static Dictionary<string, int> inventario = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n" + new string('=', 40));
                Console.WriteLine("SISTEMA DE GESTIÓN DE INVENTARIO");
                Console.WriteLine(new string('=', 40));
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Mostrar inventario");
                Console.WriteLine("3. Buscar producto");
                Console.WriteLine("4. Actualizar cantidad");
                Console.WriteLine("5. Salir");
                Console.WriteLine(new string('=', 40));

                Console.Write("Seleccione una opción (1-5): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        MostrarInventario();
                        break;
                    case "3":
                        BuscarProducto();
                        break;
                    case "4":
                        ActualizarCantidad();
                        break;
                    case "5":
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }

        static void AgregarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Cantidad: ");
            if (int.TryParse(Console.ReadLine(), out int cantidad))
            {
                if (inventario.ContainsKey(nombre))
                {
                    inventario[nombre] += cantidad;
                    Console.WriteLine($"Cantidad actualizada: {nombre} +{cantidad}");
                }
                else
                {
                    inventario.Add(nombre, cantidad);
                    Console.WriteLine($"Producto agregado: {nombre} - {cantidad} unidades");
                }
            }
            else
            {
                Console.WriteLine("Error: La cantidad debe ser un número entero");
            }
        }

        static void MostrarInventario()
        {
            if (inventario.Count == 0)
            {
                Console.WriteLine("El inventario está vacío");
                return;
            }

            Console.WriteLine("\n" + new string('=', 40));
            Console.WriteLine("INVENTARIO ACTUAL");
            Console.WriteLine(new string('=', 40));
            foreach (var producto in inventario)
            {
                Console.WriteLine($"• {producto.Key}: {producto.Value} unidades");
            }
            Console.WriteLine(new string('=', 40));
        }

        static void BuscarProducto()
        {
            Console.Write("Nombre del producto a buscar: ");
            string nombre = Console.ReadLine();

            if (inventario.ContainsKey(nombre))
            {
                Console.WriteLine($"{nombre} encontrado: {inventario[nombre]} unidades");
            }
            else
            {
                Console.WriteLine($"{nombre} no encontrado en el inventario");
            }
        }

        static void ActualizarCantidad()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            if (!inventario.ContainsKey(nombre))
            {
                Console.WriteLine($"Error: {nombre} no existe en el inventario");
                return;
            }

            Console.Write("Nueva cantidad: ");
            if (int.TryParse(Console.ReadLine(), out int nuevaCantidad))
            {
                inventario[nombre] = nuevaCantidad;
                Console.WriteLine($"{nombre} actualizado: {nuevaCantidad} unidades");
            }
            else
            {
                Console.WriteLine("Error: La cantidad debe ser un número entero");
            }
        }
    }
}




