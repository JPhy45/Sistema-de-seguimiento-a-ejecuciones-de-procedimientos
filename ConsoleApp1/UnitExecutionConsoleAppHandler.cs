using gProtos;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class UnitExecutionConsoleAppHandler
    {
        public static UnitProcedureExecutionDTO? CreateUnitProcedureExecutionAPI(GrpcChannel channel, gProtos.UnitProcedureExecution.UnitProcedureExecutionClient client)
        {
            var UnitProcedureToExecute = new UnitProcedureDTO() { Id = new Guid().ToString() };
            var createResponse = client.CreateUnitProcedureExecution(new CreateUnitProcedureExecutionRequest()
            {
                UnitProcedure = UnitProcedureToExecute

            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create UnitProcedureExecution");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }
        }

        public static void GetAllUnitProcedureExecutionAPI(GrpcChannel channel, gProtos.UnitProcedureExecution.UnitProcedureExecutionClient client)
        {
            var getResponse = client.GetAllUnitProcedureExecution(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get UnitProcedureExecution");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} ejecuciones de Unidades de procedimientos");
            }
        }

        public static void GetUnitProcedureExecutionByIdAPI(GrpcChannel channel, gProtos.UnitProcedureExecution.UnitProcedureExecutionClient client, UnitProcedureExecutionDTO createResponse)
        {
            var getByIdResponse = client.GetUnitProcedureExecution(new GetRequest() { Id = createResponse.ID.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get UnitProcedureExecution");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la unidad de procedimiento {getByIdResponse.UnitProcedureExecution.ID}");
            }

        }

        public static void DeleteUnitProcedureExecutionAPI(GrpcChannel channel, gProtos.UnitProcedureExecution.UnitProcedureExecutionClient client, UnitProcedureExecutionDTO createResponse)
        {
            client.DeleteUnitProcedureExecution(new DeleteRequest() { Id = createResponse.ID });
            var deletedGetResponse = client.GetUnitProcedureExecution(new GetRequest() { Id = createResponse.ID });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableUnitProcedureExecutionDTO.KindOneofCase.UnitProcedureExecution)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void UpdateUnitProcedureExecutionAPI(GrpcChannel channel, gProtos.UnitProcedureExecution.UnitProcedureExecutionClient client, UnitProcedureExecutionDTO createResponse)
        {
            createResponse.State = ExecutionState.Paused;
            client.UpdateUnitProcedureExecution(createResponse);

            var updatedGetResponse = client.GetUnitProcedureExecution(new GetRequest() { Id = createResponse.ID });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableUnitProcedureExecutionDTO.KindOneofCase.UnitProcedureExecution &&
                updatedGetResponse.UnitProcedureExecution.State == createResponse.State)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }
    }
}
