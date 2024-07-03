using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdentificationCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Execution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Execution", x => x.Id);
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
                        name: "FK_Procedimientos_Base_Id",
                        column: x => x.Id,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UnitCode = table.Column<string>(type: "TEXT", nullable: true),
                    UnitProcedureId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operaciones_Base_Id",
                        column: x => x.Id,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operaciones_Procedimientos_UnitProcedureId",
                        column: x => x.UnitProcedureId,
                        principalTable: "Procedimientos",
                        principalColumn: "Id");
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
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationsId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phases_Base_Id",
                        column: x => x.Id,
                        principalTable: "Base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phases_Operaciones_OperationsId",
                        column: x => x.OperationsId,
                        principalTable: "Operaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcedureOperation",
                columns: table => new
                {
                    OperationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProcedureId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureOperation", x => new { x.ProcedureId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_ProcedureOperation_Operaciones_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureOperation_Procedimientos_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationPhase",
                columns: table => new
                {
                    PhaseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationPhase", x => new { x.OperationId, x.PhaseId });
                    table.ForeignKey(
                        name: "FK_OperationPhase_Operaciones_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Operaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationPhase_Phases_PhaseId",
                        column: x => x.PhaseId,
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

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_UnitProcedureId",
                table: "Operaciones",
                column: "UnitProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationExecution_OperationId",
                table: "OperationExecution",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPhase_PhaseId",
                table: "OperationPhase",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseExecution_PhaseId",
                table: "PhaseExecution",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_OperationsId",
                table: "Phases",
                column: "OperationsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureOperation_OperationId",
                table: "ProcedureOperation",
                column: "OperationId");

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
                name: "OperationPhase");

            migrationBuilder.DropTable(
                name: "PhaseExecution");

            migrationBuilder.DropTable(
                name: "ProcedureOperation");

            migrationBuilder.DropTable(
                name: "UnitExecution");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Execution");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Procedimientos");

            migrationBuilder.DropTable(
                name: "Base");
        }
    }
}
