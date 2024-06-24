using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Utilities;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Type;
using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Contexts;
using System.Threading.Tasks;

using Sistema_de_seguimiento_a_ejecuciones_de_procedimientos.Domain.Entities;
using DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {
        //creando un contexto para ineractuar conla Base de Datos
        AplicationContext appContext = new AplicationContext("Data Source = Sistema_de_seguimiento_a_ejecuciones.sqlite");
        if (!appContext.Database.CanConnect())
        {
            appContext.Database.Migrate();

        }

        //creando una clase
        Phases phase0 = new Phases("P1", "move");
        appContext.Set<Phases>().Add(phase0);
        appContext.SaveChanges();

        Phases phase1 = new Phases("P2", "copy");
        appContext.Set<Phases>().Add(phase1);
        appContext.SaveChanges();

        Phases phase2 = new Phases("P3", "paste");
        appContext.Set<Phases>().Add(phase2);
        appContext.SaveChanges();

        Operations operation0 = new Operations("O1", "op1");
        operation0.phases.Enqueue(phase0);
        operation0.phases.Enqueue(phase1);
        operation0.phases.Enqueue(phase2);
        appContext.Set<Operations>().Add(operation0);
        appContext.SaveChanges();

        Operations operation1 = new Operations("O2", "op2");
        operation0.phases.Enqueue(phase0);
        operation0.phases.Enqueue(phase1);
        appContext.Set<Operations>().Add(operation1);
        appContext.SaveChanges();

        Operations operation2 = new Operations("O3", "op3");
        operation0.phases.Enqueue(phase1);
        operation0.phases.Enqueue(phase2);
        appContext.Set<Operations>().Add(operation2);
        appContext.SaveChanges();

        UnitProcedure unitprocedure0 = new UnitProcedure("unitprocedure1", "UP1");
        unitprocedure0.Operations.Enqueue(operation0);
        unitprocedure0.Operations.Enqueue(operation1);
        unitprocedure0.Operations.Enqueue(operation2);
        appContext.Set<UnitProcedure>().Add(unitprocedure0);
        appContext.SaveChanges();

        UnitProcedure unitprocedure1 = new UnitProcedure("unitprocedure2", "UP2");
        unitprocedure0.Operations.Enqueue(operation0);
        unitprocedure0.Operations.Enqueue(operation1);
        appContext.Set<UnitProcedure>().Add(unitprocedure1);
        appContext.SaveChanges();

        var phases=appContext.Set<Phases>().ToList();
       
    }
}