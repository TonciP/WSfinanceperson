using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    saldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccion_Cuenta_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaTransferencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CuentaOrigenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CuentaDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_CuentaDestinoId",
                        column: x => x.CuentaDestinoId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_CuentaOrigenId",
                        column: x => x.CuentaOrigenId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CuentaId",
                table: "Categoria",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaId",
                table: "Cuenta",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_CuentaId",
                table: "Transaccion",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_CuentaDestinoId",
                table: "Transferencia",
                column: "CuentaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_CuentaOrigenId",
                table: "Transferencia",
                column: "CuentaOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
