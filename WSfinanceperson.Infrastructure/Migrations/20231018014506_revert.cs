using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class revert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Cuenta_cuentaId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Persona_personaId",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaccion_Categoria_categoriaId",
                table: "Transaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaccion_Cuenta_cuentaId",
                table: "Transaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaDestinoId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaOrigenId",
                table: "Transferencia");

            migrationBuilder.RenameColumn(
                name: "cuentaOrigenId",
                table: "Transferencia",
                newName: "CuentaOrigenId");

            migrationBuilder.RenameColumn(
                name: "cuentaDestinoId",
                table: "Transferencia",
                newName: "CuentaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_cuentaOrigenId",
                table: "Transferencia",
                newName: "IX_Transferencia_CuentaOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_cuentaDestinoId",
                table: "Transferencia",
                newName: "IX_Transferencia_CuentaDestinoId");

            migrationBuilder.RenameColumn(
                name: "cuentaId",
                table: "Transaccion",
                newName: "CuentaId");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "Transaccion",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaccion_cuentaId",
                table: "Transaccion",
                newName: "IX_Transaccion_CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaccion_categoriaId",
                table: "Transaccion",
                newName: "IX_Transaccion_CategoriaId");

            migrationBuilder.RenameColumn(
                name: "personaId",
                table: "Cuenta",
                newName: "PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_personaId",
                table: "Cuenta",
                newName: "IX_Cuenta_PersonaId");

            migrationBuilder.RenameColumn(
                name: "cuentaId",
                table: "Categoria",
                newName: "CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Categoria_cuentaId",
                table: "Categoria",
                newName: "IX_Categoria_CuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cuenta_CuentaId",
                table: "Categoria",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Persona_PersonaId",
                table: "Cuenta",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaccion_Categoria_CategoriaId",
                table: "Transaccion",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaccion_Cuenta_CuentaId",
                table: "Transaccion",
                column: "CuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_CuentaDestinoId",
                table: "Transferencia",
                column: "CuentaDestinoId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_CuentaOrigenId",
                table: "Transferencia",
                column: "CuentaOrigenId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Cuenta_CuentaId",
                table: "Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Cuenta_Persona_PersonaId",
                table: "Cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaccion_Categoria_CategoriaId",
                table: "Transaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaccion_Cuenta_CuentaId",
                table: "Transaccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_CuentaDestinoId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_CuentaOrigenId",
                table: "Transferencia");

            migrationBuilder.RenameColumn(
                name: "CuentaOrigenId",
                table: "Transferencia",
                newName: "cuentaOrigenId");

            migrationBuilder.RenameColumn(
                name: "CuentaDestinoId",
                table: "Transferencia",
                newName: "cuentaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_CuentaOrigenId",
                table: "Transferencia",
                newName: "IX_Transferencia_cuentaOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_CuentaDestinoId",
                table: "Transferencia",
                newName: "IX_Transferencia_cuentaDestinoId");

            migrationBuilder.RenameColumn(
                name: "CuentaId",
                table: "Transaccion",
                newName: "cuentaId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Transaccion",
                newName: "categoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaccion_CuentaId",
                table: "Transaccion",
                newName: "IX_Transaccion_cuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaccion_CategoriaId",
                table: "Transaccion",
                newName: "IX_Transaccion_categoriaId");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Cuenta",
                newName: "personaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuenta_PersonaId",
                table: "Cuenta",
                newName: "IX_Cuenta_personaId");

            migrationBuilder.RenameColumn(
                name: "CuentaId",
                table: "Categoria",
                newName: "cuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Categoria_CuentaId",
                table: "Categoria",
                newName: "IX_Categoria_cuentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cuenta_cuentaId",
                table: "Categoria",
                column: "cuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuenta_Persona_personaId",
                table: "Cuenta",
                column: "personaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaccion_Categoria_categoriaId",
                table: "Transaccion",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaccion_Cuenta_cuentaId",
                table: "Transaccion",
                column: "cuentaId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaDestinoId",
                table: "Transferencia",
                column: "cuentaDestinoId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaOrigenId",
                table: "Transferencia",
                column: "cuentaOrigenId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
