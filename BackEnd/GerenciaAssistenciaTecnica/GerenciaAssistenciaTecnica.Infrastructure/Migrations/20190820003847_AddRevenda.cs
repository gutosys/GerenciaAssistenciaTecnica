using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddRevenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RevendaId",
                table: "EntradaAssistenciaTecnica",
                newName: "Revenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Revenda",
                table: "EntradaAssistenciaTecnica",
                newName: "RevendaId");
        }
    }
}
