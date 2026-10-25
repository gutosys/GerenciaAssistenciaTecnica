using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddEntreguePor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntreguePorId",
                table: "EntradaAssistenciaTecnica",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntreguePor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntreguePor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_EntreguePorId",
                table: "EntradaAssistenciaTecnica",
                column: "EntreguePorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaAssistenciaTecnica_EntreguePor_EntreguePorId",
                table: "EntradaAssistenciaTecnica",
                column: "EntreguePorId",
                principalTable: "EntreguePor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaAssistenciaTecnica_EntreguePor_EntreguePorId",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.DropTable(
                name: "EntreguePor");

            migrationBuilder.DropIndex(
                name: "IX_EntradaAssistenciaTecnica_EntreguePorId",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.DropColumn(
                name: "EntreguePorId",
                table: "EntradaAssistenciaTecnica");
        }
    }
}
