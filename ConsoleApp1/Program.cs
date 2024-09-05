using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleApp1;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Presione una tecla para conectar");
        Console.ReadKey();

        Console.WriteLine("Creating channel and client");
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var channel = GrpcChannel.ForAddress("http://localhost:5051", new GrpcChannelOptions { HttpHandler = httpHandler });
        if (channel is null)
        {
            Console.WriteLine("Cannot connect");
            channel.Dispose();
            return;
        }

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
                        SubMenuFase(channel);
                        break;
                    case 2:
                        SubMenuOperacion(channel);
                        break;
                    case 3:
                        SubMenuUnidadProcedimiento(channel);
                        break;
                    case 4:
                        SubMenuEjecucionFase(channel);
                        break;
                    case 5:
                        SubMenuEjecucionOperacion(channel);
                        break;
                    case 6:
                        SubMenuEjecucionUnidadProcedimiento(channel);
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

    static void SubMenuFase(GrpcChannel channel)
    {
        var Phaseclient = new gProtos.Phase.PhaseClient(channel);
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
                        PhaseConsoleAppHandler.CreatePhaseAPI(channel, Phaseclient);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        var PhaseGetTest = PhaseConsoleAppHandler.CreatePhaseAPI(channel, Phaseclient);
                        PhaseConsoleAppHandler.GetAllPhasesAPI(channel, Phaseclient, PhaseGetTest);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var PhaseUpdateTest = PhaseConsoleAppHandler.CreatePhaseAPI(channel, Phaseclient);
                        PhaseConsoleAppHandler.UpdatePhaseAPI(channel, Phaseclient, PhaseUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var PhaseDeleteTest= PhaseConsoleAppHandler.CreatePhaseAPI( channel, Phaseclient);
                        PhaseConsoleAppHandler.DeletePhaseAPI(channel, Phaseclient, PhaseDeleteTest);
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

    static void SubMenuOperacion(GrpcChannel channel)
    {
        var Operationclient = new gProtos.Operation.OperationClient(channel);
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
                        OperationConsoleAppHandler.CreateOperationAPI(channel, Operationclient);
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la Operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationGetTest = OperationConsoleAppHandler.CreateOperationAPI(channel, Operationclient);
                        OperationConsoleAppHandler.GetAllOperationsAPI(channel, Operationclient, OperationGetTest);
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationUpdateTest = OperationConsoleAppHandler.CreateOperationAPI(channel, Operationclient);
                        OperationConsoleAppHandler.UpdateOperationAPI(channel, Operationclient, OperationUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationDeleteTest = OperationConsoleAppHandler.CreateOperationAPI(channel, Operationclient);
                        OperationConsoleAppHandler.DeleteOperationAPI(channel, Operationclient, OperationDeleteTest);
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

    static void SubMenuUnidadProcedimiento(GrpcChannel channel)
    {
        var Unitclient = new gProtos.UnitProcedure.UnitProcedureClient(channel);
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
                        UnitConsoleAppHandler.CreateUnitAPI(channel, Unitclient);
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var UnitGetTest = UnitConsoleAppHandler.CreateUnitAPI(channel, Unitclient);
                        UnitConsoleAppHandler.GetUnitByIdAPI(channel, Unitclient, UnitGetTest);
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var UnitUpdateTest = UnitConsoleAppHandler.CreateUnitAPI(channel, Unitclient);
                        UnitConsoleAppHandler.UpdateOperationAPI(channel, Unitclient, UnitUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var UnitDeleteTest = UnitConsoleAppHandler.CreateUnitAPI(channel, Unitclient);
                        UnitConsoleAppHandler.DeleteUnitAPI(channel, Unitclient, UnitDeleteTest);
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

    static void SubMenuEjecucionFase(GrpcChannel channel)
    {
        var PhaseExecutionclient = new gProtos.PhaseExecution.PhaseExecutionClient(channel);
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
                        PhaseExecutionConsoleAppHandler.CreatePhaseExecutionAPI(channel, PhaseExecutionclient);
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var PhaseExecutionGetTest = PhaseExecutionConsoleAppHandler.CreatePhaseExecutionAPI(channel, PhaseExecutionclient);
                        PhaseExecutionConsoleAppHandler.GetPhaseExecutionByIdAPI(channel, PhaseExecutionclient, PhaseExecutionGetTest);
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var PhaseExecutionUpdateTest = PhaseExecutionConsoleAppHandler.CreatePhaseExecutionAPI(channel, PhaseExecutionclient);
                        PhaseExecutionConsoleAppHandler.UpdatePhaseExecutionAPI(channel, PhaseExecutionclient, PhaseExecutionUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la ejecucion de fase");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var PhaseExecutionDeleteTest = PhaseExecutionConsoleAppHandler.CreatePhaseExecutionAPI(channel, PhaseExecutionclient);
                        PhaseExecutionConsoleAppHandler.GetPhaseExecutionByIdAPI(channel, PhaseExecutionclient, PhaseExecutionDeleteTest);
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

    static void SubMenuEjecucionOperacion(GrpcChannel channel)
    {
        var OperationExecutionclient = new gProtos.OperationExecution.OperationExecutionClient(channel);
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
                        OperationExecutionConsoleAppHandler.CreateOperationExecutionAPI(channel, OperationExecutionclient);
                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationExecutionGetTest = OperationExecutionConsoleAppHandler.CreateOperationExecutionAPI(channel, OperationExecutionclient);
                        OperationExecutionConsoleAppHandler.GetOperationExecutionByIdAPI(channel, OperationExecutionclient, OperationExecutionGetTest);
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationExecutionUpdateTest = OperationExecutionConsoleAppHandler.CreateOperationExecutionAPI(channel, OperationExecutionclient);
                        OperationExecutionConsoleAppHandler.UpdateOperationExecutionAPI(channel, OperationExecutionclient, OperationExecutionUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la ejecucion de operacion");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var OperationExecutionDeleteTest = OperationExecutionConsoleAppHandler.CreateOperationExecutionAPI(channel, OperationExecutionclient);
                        OperationExecutionConsoleAppHandler.DeleteOperationExecutionAPI(channel, OperationExecutionclient, OperationExecutionDeleteTest);
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

    static void SubMenuEjecucionUnidadProcedimiento(GrpcChannel channel)
    {
        var UnitExecutionClient = new gProtos.UnitProcedureExecution.UnitProcedureExecutionClient(channel);
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
                        UnitExecutionConsoleAppHandler.CreateUnitProcedureExecutionAPI(channel, UnitExecutionClient);

                        break;
                    case 2:
                        Console.WriteLine("Obtener información de la Ejecucion de unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        UnitExecutionConsoleAppHandler.GetAllUnitProcedureExecutionAPI(channel, UnitExecutionClient);
                        break;
                    case 3:
                        Console.WriteLine("Actualizar información de la Ejecucion de unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var UnitExecutionUpdateTest = UnitExecutionConsoleAppHandler.CreateUnitProcedureExecutionAPI(channel, UnitExecutionClient);
                        UnitExecutionConsoleAppHandler.UpdateUnitProcedureExecutionAPI(channel, UnitExecutionClient, UnitExecutionUpdateTest);
                        break;
                    case 4:
                        Console.WriteLine("Eliminar información de la unidad de procedimiento");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        var UnitExecutionDeleteTest = UnitExecutionConsoleAppHandler.CreateUnitProcedureExecutionAPI(channel, UnitExecutionClient);
                        UnitExecutionConsoleAppHandler.UpdateUnitProcedureExecutionAPI(channel, UnitExecutionClient, UnitExecutionDeleteTest);
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


