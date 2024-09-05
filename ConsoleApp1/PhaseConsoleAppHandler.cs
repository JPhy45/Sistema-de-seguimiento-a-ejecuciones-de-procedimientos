using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp1
{
    public static class PhaseConsoleAppHandler
    {
        public static PhaseDTO? CreatePhaseAPI(GrpcChannel channel, gProtos.Phase.PhaseClient client)
        {
            var createResponse = client.CreatePhase(new CreatePhaseRequest()
            {
                Name = "Fase 1",
                IdentificationCode = "0001"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create phase");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }


        }

        public static void GetAllPhasesAPI(GrpcChannel channel, gProtos.Phase.PhaseClient client, PhaseDTO createResponse)
        {
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
        }

        public static void GetPhaseByIdAPI(GrpcChannel channel, gProtos.Phase.PhaseClient client, PhaseDTO createResponse)
        {
            createResponse.Name = "Fase 2";
            client.UpdatePhase(createResponse);

            var updatedGetResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullablePhaseDTO.KindOneofCase.Phases &&
                updatedGetResponse.Phases.Name == createResponse.Name)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

        public static void DeletePhaseAPI(GrpcChannel channel, gProtos.Phase.PhaseClient client, PhaseDTO createResponse)
        {
            client.DeletePhase(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullablePhaseDTO.KindOneofCase.Phases)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void UpdatePhaseAPI(GrpcChannel channel, gProtos.Phase.PhaseClient client, PhaseDTO createResponse)
        {
            Console.WriteLine("Presione una tecla para modificar la fase");
            Console.ReadKey();
            createResponse.Name = "Fase 2";
            client.UpdatePhase(createResponse);

            var updatedGetResponse = client.GetPhase(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullablePhaseDTO.KindOneofCase.Phases &&
                updatedGetResponse.Phases.Name == createResponse.Name)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

        }

    }
}
