using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddClienteAssociadoTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acessorios",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "ClienteAssociado",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "ClienteAssociado");

            migrationBuilder.AddColumn<string>(
                name: "Acessorios",
                table: "EntradaAssistenciaTecnica",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
