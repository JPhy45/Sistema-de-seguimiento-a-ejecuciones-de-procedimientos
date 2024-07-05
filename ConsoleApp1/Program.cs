using Contracts;
using Contracts.Procedures;
using Contracts.Executions;
using DataAccess.Contexts;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Domain.Domain.Entities;
using Tests.Utilities;
using DataAccess.Repositories.Executions;
using DataAccess.Repositories.Procedures;
using Domain.Domain.Utilities;

internal class Program
{
    static async Task Main(string[] args)
    {
        if (File.Exists("Data.sqlite"))
            File.Delete("Data.sqlite");

        AplicationContext context = new AplicationContext(ConnectionStringProvider.GetConnectionString());

        if (!context.Database.CanConnect())
            context.Database.Migrate();

        IUnitOfWork UnitOfWork = new UnitOfWork(context);
        IExecutionRepository ExecutionRepository = new ExecutionRepository (context);
        IProcedureControlRepository BaseRepository = new ProcedureControlRepository(context);

        Phases phase1 = new Phases("P1", "Phase 1");
        Phases phase2 = new Phases("P2", "Phase 2");
        Operations Operation1 = new Operations("O1", "Operation 1");
        Operations Operation2 = new Operations("O2", "Operation 2");
        UnitProcedure Unit1 = new UnitProcedure("U1","Unit 1");
        UnitProcedure Unit2 = new UnitProcedure("U2", "Unit 2");

        PhaseExecution phaseExecution = new PhaseExecution(phase2);
        OperationExecution operationExecution = new OperationExecution(Operation2);
        UnitExecution unitExecution = new UnitExecution(Unit1);

        BaseRepository.Add(phase1);
        BaseRepository.Add(phase2);
        BaseRepository.Add(Operation2);
        BaseRepository.Add(Operation1);
        BaseRepository.Add(Unit1);
        BaseRepository.Add(Unit2);

        ExecutionRepository.AddExecution(phaseExecution);
        ExecutionRepository.AddExecution(operationExecution);
        ExecutionRepository.AddExecution(unitExecution);

        context.SaveChanges();

        Phases? phasetoload = BaseRepository.GetById<Phases>(phaseExecution.PhaseId);
        if (phasetoload == null)
            Console.WriteLine("La entidad Phase de la Ejecucion de Fase 1 no se encuentra en BD");
        else
            Console.WriteLine($"Se esta ejecutando la fase {phasetoload.Name}");
        phase1.Description = "TODELETE";

        BaseRepository.Update(phase1);
        UnitOfWork.SaveChanges();

        BaseRepository.Delete(phase1);
        UnitOfWork.SaveChanges();
        
        Phases? deletedPhase = BaseRepository.GetById<Phases>(phase1.Id);
        if (deletedPhase == null)
            Console.WriteLine($"Phase {phase1.Name} eliminada Correctamente");


    }
}