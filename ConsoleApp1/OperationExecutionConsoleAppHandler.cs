using gProtos;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class OperationExecutionConsoleAppHandler
    {
        public static OperationExecutionDTO? CreateOperationExecutionAPI(GrpcChannel channel, gProtos.OperationExecution.OperationExecutionClient client)
        {
            var OperationToExecute = new OperationDTO() { Id = new Guid().ToString() };
            var createResponse = client.CreateOperationExecution(new CreateOperationExecutionRequest()
            {
                Operation = OperationToExecute

            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create OperationExecution");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }
        }

        public static void GetAllOperationExecutionAPI(GrpcChannel channel, gProtos.OperationExecution.OperationExecutionClient client)
        {
            var getResponse = client.GetAllOperationExecution(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get OperationExecution");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} ejecuciones de operaciones");
            }
        }

        public static void GetOperationExecutionByIdAPI(GrpcChannel channel, gProtos.OperationExecution.OperationExecutionClient client, OperationExecutionDTO createResponse)
        {
            var getByIdResponse = client.GetOperationExecution(new GetRequest() { Id = createResponse.ID.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get OperationExecution");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la operacion {getByIdResponse.OperationExecution.ID}");
            }

        }

        public static void DeleteOperationExecutionAPI(GrpcChannel channel, gProtos.OperationExecution.OperationExecutionClient client, OperationExecutionDTO createResponse)
        {
            client.DeleteOperationExecution(new DeleteRequest() { Id = createResponse.ID });
            var deletedGetResponse = client.GetOperationExecution(new GetRequest() { Id = createResponse.ID });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableOperationExecutionDTO.KindOneofCase.OperationExecution)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void UpdateOperationExecutionAPI(GrpcChannel channel, gProtos.OperationExecution.OperationExecutionClient client, OperationExecutionDTO createResponse)
        {
            createResponse.State = ExecutionState.Paused;
            client.UpdateOperationExecution(createResponse);

            var updatedGetResponse = client.GetOperationExecution(new GetRequest() { Id = createResponse.ID });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableOperationExecutionDTO.KindOneofCase.OperationExecution &&
                updatedGetResponse.OperationExecution.State == createResponse.State)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }
    }
}