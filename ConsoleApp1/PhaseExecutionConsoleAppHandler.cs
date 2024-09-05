using gProtos;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class PhaseExecutionConsoleAppHandler
    {
        public static PhaseExecutionDTO? CreatePhaseExecutionAPI(GrpcChannel channel, gProtos.PhaseExecution.PhaseExecutionClient client)
        {
            var PhaseToExecute = new PhaseDTO() { Id = new Guid().ToString() };
            var createResponse = client.CreatePhaseExecution(new CreatePhaseExecutionRequest()
            {
                Phase = PhaseToExecute

            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create PhaseExecution");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }
        }

        public static void GetAllPhaseExecutionAPI(GrpcChannel channel, gProtos.PhaseExecution.PhaseExecutionClient client)
        {
            var getResponse1 = client.GetAllPhaseExecution(new Google.Protobuf.WellKnownTypes.Empty());
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
        }
    
        public static void GetPhaseExecutionByIdAPI(GrpcChannel channel, gProtos.PhaseExecution.PhaseExecutionClient client, PhaseExecutionDTO createResponse) 
        {
            var getByIdResponse1 = client.GetPhaseExecution(new GetRequest() { Id = createResponse.ID.ToString() });
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

        }

        public static void DeletePhaseExecutionAPI(GrpcChannel channel, gProtos.PhaseExecution.PhaseExecutionClient client, PhaseExecutionDTO createResponse)
        {
            client.DeletePhaseExecution(new DeleteRequest() { Id = createResponse.ID });
            var deletedGetResponse1 = client.GetPhaseExecution(new GetRequest() { Id = createResponse.ID });
            if (deletedGetResponse1 is null ||
                deletedGetResponse1.KindCase != NullablePhaseExecutionDTO.KindOneofCase.PhaseExecution)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }

        public static void UpdatePhaseExecutionAPI(GrpcChannel channel, gProtos.PhaseExecution.PhaseExecutionClient client, PhaseExecutionDTO createResponse)
        {
            createResponse.State = ExecutionState.Paused;
            client.UpdatePhaseExecution(createResponse);

            var updatedGetResponse1 = client.GetPhaseExecution(new GetRequest() { Id = createResponse.ID });
            if (updatedGetResponse1 is not null &&
                updatedGetResponse1.KindCase == NullablePhaseExecutionDTO.KindOneofCase.PhaseExecution &&
                updatedGetResponse1.PhaseExecution.State == createResponse.State)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }
    }
}
