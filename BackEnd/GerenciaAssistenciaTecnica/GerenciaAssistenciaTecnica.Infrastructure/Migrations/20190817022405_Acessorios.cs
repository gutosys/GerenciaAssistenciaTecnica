using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class Acessorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradaAssistenciaAcessorio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcessorioId = table.Column<int>(nullable: false),
                    EntradaAssistenciaTecnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaAssistenciaAcessorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaAcessorio_Acessorio_AcessorioId",
                        column: x => x.AcessorioId,
                        principalTable: "Acessorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaAcessorio_EntradaAssistenciaTecnica_EntradaAssistenciaTecnicaId",
                        column: x => x.EntradaAssistenciaTecnicaId,
                        principalTable: "EntradaAssistenciaTecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaAcessorio_AcessorioId",
                table: "EntradaAssistenciaAcessorio",
                column: "AcessorioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaAcessorio_EntradaAssistenciaTecnicaId",
                table: "EntradaAssistenciaAcessorio",
                column: "EntradaAssistenciaTecnicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaAssistenciaAcessorio");
        }
    }
}
