using System;

class Program
{
    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal");
            Console.WriteLine("----------------");
            Console.WriteLine("1. Trabajar con una fase");
            Console.WriteLine("2. Trabajar con una operación");
            Console.WriteLine("3. Trabajar con una unidad de procedimiento");
            Console.WriteLine("4. Trabajar con una ejecución de una fase");
            Console.WriteLine("5. Trabajar con una ejecución de una operación");
            Console.WriteLine("6. Trabajar con una ejecución de una unidad de procedimiento");
            Console.WriteLine("7. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        SubMenuFase();
                        break;
                    case 2:
                        SubMenuOperacion();
                        break;
                    case 3:
                        SubMenuUnidadProcedimiento();
                        break;
                    case 4:
                        SubMenuEjecucionFase();
                        break;
                    case 5:
                        SubMenuEjecucionOperacion();
                        break;
                    case 6:
                        SubMenuEjecucionUnidadProcedimiento();
                        break;
                    case 7:
                        continue;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuFase()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Fase");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuOperacion()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Operacion");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear Operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la Operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuUnidadProcedimiento()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Fase");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuEjecucionFase()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Ejecucion de fase");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuEjecucionOperacion()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Ejecucion de operacion");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void SubMenuEjecucionUnidadProcedimiento()
    {
        bool salirSubMenu = false;
        while (!salirSubMenu)
        {
            Console.Clear();
            Console.WriteLine("Menú Ejecucion de unidad de procedimiento");
            Console.WriteLine("---------");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Obtener");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Borrar");
            Console.WriteLine("5. Regresar al menú principal");

            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = -1;
            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Crear Ejecucion de unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la Ejecucion de unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la Ejecuion de unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero.");
            }

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}


