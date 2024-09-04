using Aplication;
using Contracts;
using Contracts.Executions;
using Contracts.Procedures;
using DataAccess;
using DataAccess.Contexts;
using DataAccess.Repositories.Executions;
using DataAccess.Repositories.Procedures;
using GrpcService.Services;

namespace CarDealer.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<AplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProcedureControlRepository, ProcedureControlRepository>();
            builder.Services.AddScoped<IExecutionRepository, ExecutionRepository>();


            //builder.Services.AddScoped<IPriceRepository, ApplicationRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<PhasesService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}