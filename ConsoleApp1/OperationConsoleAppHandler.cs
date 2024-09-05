using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp1
{
    public static class OperationConsoleAppHandler
    {
        public static OperationDTO? CreateOperationAPI(GrpcChannel channel, gProtos.Operation.OperationClient client)
        {
            var createResponse = client.CreateOperation(new CreateOperationRequest()
            {
                Name = "Operacion 1",
                IdentificationCode = "0001"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create Operation");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }


        }

        public static void GetAllOperationsAPI(GrpcChannel channel, gProtos.Operation.OperationClient client, OperationDTO createResponse)
        {
            var getResponse = client.GetAllOperations(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get operation");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} operaciones");
            }



        }

        public static void GetOperationByIdAPI(GrpcChannel channel, gProtos.Operation.OperationClient client, OperationDTO createResponse)
        {
            Console.WriteLine($"Presione una tecla para obtener la operacion con Id {createResponse.Id}");
            Console.ReadKey();

            var getByIdResponse = client.GetOperation(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get operation");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la operacion {getByIdResponse.Operations.Id}");
            }

        }

        public static void DeleteOperationAPI(GrpcChannel channel, gProtos.Operation.OperationClient client, OperationDTO createResponse)
        {
            client.DeleteOperation(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetOperation(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableOperationDTO.KindOneofCase.Operations)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }
        public static void UpdateOperationAPI(GrpcChannel channel, gProtos.Operation.OperationClient client, OperationDTO createResponse)
        {
            Console.WriteLine("Presione una tecla para modificar la operacion");
            Console.ReadKey();
            createResponse.Name = "Operacion 2";
            client.UpdateOperations(createResponse);

            var updatedGetResponse = client.GetOperation(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableOperationDTO.KindOneofCase.Operations &&
                updatedGetResponse.Operations.Name == createResponse.Name)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

    }
}