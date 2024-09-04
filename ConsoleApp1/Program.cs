using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
        var createResponse = client.CreatePhase(new CreatePhaseRequest()
        {
            Name = "Fase 1",
            IdentificationCode="0001"
        });

        if (createResponse is null)
        {
            Console.WriteLine("Cannot create phase");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Creación exitosa.");
        }

        Console.WriteLine("Presione una tecla para obtener todas las fases");
        Console.ReadKey();
        var getResponse = client.GetAllPhases(new Google.Protobuf.WellKnownTypes.Empty());
        if (getResponse.Items is null)
        {
            Console.WriteLine("Cannot get phase");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} fases");
        }

        Console.WriteLine($"Presione una tecla para obtener la fase con Id {createResponse.Id}");
        Console.ReadKey();
        var getByIdResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id.ToString() });
        if (getByIdResponse is null)
        {
            Console.WriteLine("Cannot get fase");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Obtención exitosa de la fase {getByIdResponse.Phases.Id}");
        }

        Console.WriteLine("Presione una tecla para modificar la fase");
        Console.ReadKey();
        createResponse.Name= "Fase 2";
        client.UpdatePhase(createResponse);

        var updatedGetResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id });
        if (updatedGetResponse is not null &&
            updatedGetResponse.KindCase == NullablePhaseDTO.KindOneofCase.Phases &&
            updatedGetResponse.Phases.Name == createResponse.Name)
        {
            Console.WriteLine($"Modificación exitosa.");
        }

        
        var client1 = new gProtos.PhaseExecution.PhaseExecutionClient(channel);

        Console.WriteLine("Presione una tecla para crear la ejecucion de una fase");
        Console.ReadKey();
        var PhaseToExecute = new PhaseDTO() { Id = new Guid().ToString()};
        var createResponse1 = client1.CreatePhaseExecution(new CreatePhaseExecutionRequest()
        {
            Phase = PhaseToExecute

        });

        if (createResponse is null)
        {
            Console.WriteLine("Cannot create PhaseExecution");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Creación exitosa.");
        }

        Console.WriteLine("Presione una tecla para obtener todas las ejecuciones de fase");
        Console.ReadKey();
        var getResponse1 = client1.GetAllPhaseExecution(new Google.Protobuf.WellKnownTypes.Empty());
        if (getResponse1.Items is null)
        {
            Console.WriteLine("Cannot get phaseExecution");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Obtención exitosa de {getResponse1.Items.Count} ejecuciones de fase");
        }

        Console.WriteLine($"Presione una tecla para obtener la fase con Id {createResponse1.ID}");
        Console.ReadKey();
        var getByIdResponse1 = client1.GetPhaseExecution(new GetRequest() { Id = createResponse1.ID.ToString() });
        if (getByIdResponse1 is null)
        {
            Console.WriteLine("Cannot get faseExecution");
            channel.Dispose();
            return;
        }
        else
        {
            Console.WriteLine($"Obtención exitosa de la fase {getByIdResponse1.PhaseExecution.ID}");
        }

        Console.WriteLine("Presione una tecla para modificar la faseExecution");
        Console.ReadKey();
        createResponse1.State = ExecutionState.Paused;
        client1.UpdatePhaseExecution(createResponse1);

        var updatedGetResponse1 = client1.GetPhaseExecution(new GetRequest() { Id = createResponse1.ID });
        if (updatedGetResponse1 is not null &&
            updatedGetResponse1.KindCase == NullablePhaseExecutionDTO.KindOneofCase.PhaseExecution &&
            updatedGetResponse1.PhaseExecution.State== createResponse1.State)
        {
            Console.WriteLine($"Modificación exitosa.");
        }

        Console.WriteLine("Presione una tecla para eliminar la faseExecution");
        Console.ReadKey();

        client1.DeletePhaseExecution(new DeleteRequest() { Id = createResponse1.ID });
        var deletedGetResponse1 = client1.GetPhaseExecution(new GetRequest() { Id = createResponse1.ID });
        if (deletedGetResponse1 is null ||
            deletedGetResponse1.KindCase != NullablePhaseExecutionDTO.KindOneofCase.PhaseExecution)
        {
            Console.WriteLine($"Eliminación exitosa.");
        }
        Console.WriteLine("Presione una tecla para eliminar la fase");
        Console.ReadKey();

        client.DeletePhase(new DeleteRequest() { Id = createResponse.Id });
        var deletedGetResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id });
        if (deletedGetResponse is null ||
            deletedGetResponse.KindCase != NullablePhaseDTO.KindOneofCase.Phases)
        {
            Console.WriteLine($"Eliminación exitosa.");
        }


        channel.Dispose();


    }
}