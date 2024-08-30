using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Execution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Execution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdentificationCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureControl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_ProcedureControl_Id",
                        column: x => x.Id,
                        principalTable: "ProcedureControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phases_ProcedureControl_Id",
                        column: x => x.Id,
                        principalTable: "ProcedureControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procedimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedimientos_ProcedureControl_Id",
                        column: x => x.Id,
                        principalTable: "ProcedureControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationExecution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpperCode = table.Column<string>(type: "TEXT", nullable: true),
                    OperationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationExecution_Execution_Id",
                        column: x => x.Id,
                        principalTable: "Execution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationExecution_Operaciones_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationsPhases",
                columns: table => new
                {
                    PhasesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    operationsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsPhases", x => new { x.PhasesId, x.operationsId });
                    table.ForeignKey(
                        name: "FK_OperationsPhases_Operaciones_operationsId",
                        column: x => x.operationsId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationsPhases_Phases_PhasesId",
                        column: x => x.PhasesId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseExecution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UpperCode = table.Column<string>(type: "TEXT", nullable: true),
                    PhaseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhaseExecution_Execution_Id",
                        column: x => x.Id,
                        principalTable: "Execution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhaseExecution_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationsUnitProcedure",
                columns: table => new
                {
                    OperationsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitProceduresId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsUnitProcedure", x => new { x.OperationsId, x.UnitProceduresId });
                    table.ForeignKey(
                        name: "FK_OperationsUnitProcedure_Operaciones_OperationsId",
                        column: x => x.OperationsId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationsUnitProcedure_Procedimientos_UnitProceduresId",
                        column: x => x.UnitProceduresId,
                        principalTable: "Procedimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitExecution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitExecution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitExecution_Execution_Id",
                        column: x => x.Id,
                        principalTable: "Execution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitExecution_Procedimientos_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Procedimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationExecution_OperationId",
                table: "OperationExecution",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationsPhases_operationsId",
                table: "OperationsPhases",
                column: "operationsId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationsUnitProcedure_UnitProceduresId",
                table: "OperationsUnitProcedure",
                column: "UnitProceduresId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseExecution_PhaseId",
                table: "PhaseExecution",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitExecution_UnitId",
                table: "UnitExecution",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationExecution");

            migrationBuilder.DropTable(
                name: "OperationsPhases");

            migrationBuilder.DropTable(
                name: "OperationsUnitProcedure");

            migrationBuilder.DropTable(
                name: "PhaseExecution");

            migrationBuilder.DropTable(
                name: "UnitExecution");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Execution");

            migrationBuilder.DropTable(
                name: "Procedimientos");

            migrationBuilder.DropTable(
                name: "ProcedureControl");
        }
    }
}
