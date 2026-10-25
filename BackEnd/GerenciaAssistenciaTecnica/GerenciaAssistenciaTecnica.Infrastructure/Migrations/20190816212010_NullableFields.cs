using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class NullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaquinaId",
                table: "EntradaAssistenciaTecnica",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "EntradaAssistenciaTecnica",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaquinaId",
                table: "EntradaAssistenciaTecnica",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "EntradaAssistenciaTecnica",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
