﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;


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
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
