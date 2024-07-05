using DataAccess.FluentConfigurations.Procedures;
using DataAccess.FluentConfigurations.Executions;
using Microsoft.EntityFrameworkCore;
using Domain.Domain.Entities;
using Domain.Domain.Utilities;

namespace DataAccess.Contexts
{
    public class AplicationContext : DbContext
    {
        #region DbSets
        /// <summary>
        /// tabla para las fases, operaciones y procedimientos
        /// </summary>
        public DbSet<ProcedureControl> Base { get; set; }
        /// <summary>
        /// tabla para las ejecuciones
        /// </summary>
        public DbSet<Execution> Executions { get; set; }
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
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
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
            modelBuilder.ApplyConfiguration(new ProcedureControlEntityTypeConfiguration());
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
