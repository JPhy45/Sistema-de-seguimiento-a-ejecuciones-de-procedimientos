using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;
using DataAccess.FluentConfigurations.Bases;
using DataAccess.FluentConfigurations.Executions;

namespace DataAccess.Contexts
{
    public class AplicationContext : DbContext
    {
        #region DbSets
        /// <summary>
        /// tabla para las fases, operaciones y procedimientos
        /// </summary>
        public DbSet<Base>? Phases { get; set; }
        /// <summary>
        /// tabla para las ejecuciones
        /// </summary>
        public DbSet<Execution>? Executions { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Requerido por entityFramework para las migraciones
        /// </summary>
        public AplicationContext() { }
        /// <summary>
        /// inicializa un objeto aplicationCOntext
        /// </summary>
        /// <param name="options"></param>
        public AplicationContext(DbContextOptions<AplicationContext> options) : base (options)
        { 
        }

        public AplicationContext(string connectionString)
            : base(GetOptions(connectionString))
        { 
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OperationPhase>().
                HasKey(OP => new { OP.OperationId, OP.PhaseId });

            modelBuilder.Entity<OperationPhase>().
                HasOne(OP => OP.Operation).
                WithMany(O => O.OperationPhase).
                HasForeignKey(OP => OP.PhaseId);

            modelBuilder.Entity<OperationPhase>().
                HasOne(OP => OP.Phase).
                WithMany(P => P.OperationsPhase).
                HasForeignKey(OP => OP.PhaseId);

            modelBuilder.Entity<ProcedureOperation>().
                HasKey(PO => new { PO.ProcedureId, PO.OperationId });

            modelBuilder.Entity<ProcedureOperation>().
                HasOne(PO => PO.UnitProcedure).
                WithMany(P => P.ProcedureOperation).
                HasForeignKey(PO => PO.ProcedureId);

            modelBuilder.Entity<ProcedureOperation>().
                HasOne(PO => PO.Operation).
                WithMany(O => O.ProcedureOperation).
                HasForeignKey(PO => PO.OperationId);


            modelBuilder.ApplyConfiguration(new BaseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OperationsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhasesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitProcedureEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExecutionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OperationExecutionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PhaseExecutionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnitExecutionEntityTypeConfiguration());


        }
        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

    }
}
