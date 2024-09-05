using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConsoleApp1
{
    public static class UnitConsoleAppHandler
    {
        public static UnitProcedureDTO? CreateUnitAPI(GrpcChannel channel, gProtos.UnitProcedure.UnitProcedureClient client)
        {
            var createResponse = client.CreateUnitProcedure(new CreateUnitProcedureRequest()
            {
                Name = "Unidad de procedimiento 1",
                IdentificationCode = "0001"
            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create UnitProcedure");
                channel.Dispose();
                return createResponse;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
                return createResponse;
            }


        }

        public static void GetAllUnitAPI(GrpcChannel channel, gProtos.UnitProcedure.UnitProcedureClient client, UnitProcedureDTO createResponse)
        {
            var getResponse = client.GetAllUnitProcedures(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get UnitProcedure");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} unidades de procedimientos");
            }



        }

        public static void GetUnitByIdAPI(GrpcChannel channel, gProtos.UnitProcedure.UnitProcedureClient client, UnitProcedureDTO createResponse)
        {
            Console.WriteLine($"Presione una tecla para obtener la operacion con Id {createResponse.Id}");
            Console.ReadKey();

            var getByIdResponse = client.GetUnitProcedure(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get UnitProcedure");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la unidad de procedimiento {getByIdResponse.UnitProcedure.Id}");
            }

        }

        public static void DeleteUnitAPI(GrpcChannel channel, gProtos.UnitProcedure.UnitProcedureClient client, UnitProcedureDTO createResponse)
        {
            client.DeleteUnitProcedure(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetUnitProcedure(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableUnitProcedureDTO.KindOneofCase.UnitProcedure)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }
        }
        public static void UpdateOperationAPI(GrpcChannel channel, gProtos.UnitProcedure.UnitProcedureClient client, UnitProcedureDTO createResponse)
        {
            Console.WriteLine("Presione una tecla para modificar la unidad de procedimiento");
            Console.ReadKey();
            createResponse.Name = "Unidad de procedimiento 2";
            client.UpdateUnitProcedure(createResponse);

            var updatedGetResponse = client.GetUnitProcedure(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableUnitProcedureDTO.KindOneofCase.UnitProcedure &&
                updatedGetResponse.UnitProcedure.Name == createResponse.Name)
            {
                Console.WriteLine($"Modificación exitosa.");
            }
        }

    }
}