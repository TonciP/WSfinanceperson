using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class altertransferencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_cuentadestinoId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaorigenId",
                table: "Transferencia");

            migrationBuilder.RenameColumn(
                name: "cuentaorigenId",
                table: "Transferencia",
                newName: "CuentaOrigenId");

            migrationBuilder.RenameColumn(
                name: "cuentadestinoId",
                table: "Transferencia",
                newName: "CuentaDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_cuentaorigenId",
                table: "Transferencia",
                newName: "IX_Transferencia_CuentaOrigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_cuentadestinoId",
                table: "Transferencia",
                newName: "IX_Transferencia_CuentaDestinoId");

            migrationBuilder.AlterColumn<decimal>(
                name: "saldoInicial",
                table: "Cuenta",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
                name: "FK_Transferencia_Cuenta_CuentaDestinoId",
                table: "Transferencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencia_Cuenta_CuentaOrigenId",
                table: "Transferencia");

            migrationBuilder.RenameColumn(
                name: "CuentaOrigenId",
                table: "Transferencia",
                newName: "cuentaorigenId");

            migrationBuilder.RenameColumn(
                name: "CuentaDestinoId",
                table: "Transferencia",
                newName: "cuentadestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_CuentaOrigenId",
                table: "Transferencia",
                newName: "IX_Transferencia_cuentaorigenId");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencia_CuentaDestinoId",
                table: "Transferencia",
                newName: "IX_Transferencia_cuentadestinoId");

            migrationBuilder.AlterColumn<double>(
                name: "saldoInicial",
                table: "Cuenta",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_cuentadestinoId",
                table: "Transferencia",
                column: "cuentadestinoId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencia_Cuenta_cuentaorigenId",
                table: "Transferencia",
                column: "cuentaorigenId",
                principalTable: "Cuenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
