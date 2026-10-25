using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddNSEntradaAssstencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NS",
                table: "EntradaAssistenciaTecnica",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NS",
                table: "EntradaAssistenciaTecnica");
        }
    }
}
