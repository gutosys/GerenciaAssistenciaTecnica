using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddRevendaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RevendaId",
                table: "EntradaAssistenciaTecnica",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevendaId",
                table: "EntradaAssistenciaTecnica");
        }
    }
}
