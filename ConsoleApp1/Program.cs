using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
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

        var client = new gProtos.Phase.PhaseClient(channel);

        Console.WriteLine("Presione una tecla para crear una fase");
        Console.ReadKey();
   
        var createResponse = PhaseConsoleAppHandler.CreatePhaseAPI(channel, client);

        Console.WriteLine("Presione una tecla para obtener todas las fases");
        Console.ReadKey();

        PhaseConsoleAppHandler.GetAllPhasesAPI(channel, client, createResponse);

        Console.WriteLine("Presione una tecla para modificar la fase");
        Console.ReadKey();

       PhaseConsoleAppHandler.GetPhaseByIdAPI(channel, client, createResponse);

        
        var client1 = new gProtos.PhaseExecution.PhaseExecutionClient(channel);

        Console.WriteLine("Presione una tecla para crear la ejecucion de una fase");
        Console.ReadKey();

        var createResponse1 = PhaseExecutionConsoleAppHandler.CreatePhaseExecutionAPI(channel, client1 );

        Console.WriteLine("Presione una tecla para obtener todas las ejecuciones de fase");
        Console.ReadKey();

        PhaseExecutionConsoleAppHandler.GetAllPhaseExecutionAPI(channel, client1);

        Console.WriteLine($"Presione una tecla para obtener la fase con Id {createResponse1.ID}");
        Console.ReadKey();

        PhaseExecutionConsoleAppHandler.GetPhaseExecutionByIdAPI(channel, client1, createResponse1 );

        Console.WriteLine("Presione una tecla para modificar la faseExecution");
        Console.ReadKey();

        PhaseExecutionConsoleAppHandler.UpdatePhaseExecutionAPI(channel, client1, createResponse1 );


        Console.WriteLine("Presione una tecla para eliminar la faseExecution");
        Console.ReadKey();

        PhaseExecutionConsoleAppHandler.DeletePhaseExecutionAPI(channel, client1, createResponse1);

        Console.WriteLine("Presione una tecla para eliminar la fase");
        Console.ReadKey();

        PhaseConsoleAppHandler.DeletePhaseAPI(channel, client, createResponse);


        channel.Dispose();


    }
}