using AutoMapper;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;
using gProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    public static class PhaseConsoleHandler
    {
       public static PhaseDTO? CreatePhaseAPI(GrpcChannel channel,gProtos.Phase.PhaseClient client )
        {

            Console.WriteLine("Presione una tecla para crear una fase");
            Console.ReadKey();
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


    }
}
