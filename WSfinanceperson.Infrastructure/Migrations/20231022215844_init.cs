using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    personaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_personaId",
                        column: x => x.personaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Cuenta_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaOrigenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cuentaDestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaTransferencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_cuentaDestinoId",
                        column: x => x.cuentaDestinoId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cuenta_cuentaOrigenId",
                        column: x => x.cuentaOrigenId,
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
                    cuentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaccion_Categoria_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Transaccion_Cuenta_cuentaId",
                        column: x => x.cuentaId,
                        principalTable: "Cuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_cuentaId",
                table: "Categoria",
                column: "cuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_personaId",
                table: "Cuenta",
                column: "personaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_correo",
                table: "Persona",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_categoriaId",
                table: "Transaccion",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaccion_cuentaId",
                table: "Transaccion",
                column: "cuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_cuentaDestinoId",
                table: "Transferencia",
                column: "cuentaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_cuentaOrigenId",
                table: "Transferencia",
                column: "cuentaOrigenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
