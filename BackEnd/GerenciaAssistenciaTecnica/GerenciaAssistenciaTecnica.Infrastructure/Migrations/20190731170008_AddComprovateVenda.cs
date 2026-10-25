using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class AddComprovateVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NumeroComprovanteCompra",
                table: "EntradaAssistenciaTecnica",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ComprovanteCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprovanteCompra", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica",
                column: "ComprovanteCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaAssistenciaTecnica_ComprovanteCompra_ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica",
                column: "ComprovanteCompraId",
                principalTable: "ComprovanteCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaAssistenciaTecnica_ComprovanteCompra_ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.DropTable(
                name: "ComprovanteCompra");

            migrationBuilder.DropIndex(
                name: "IX_EntradaAssistenciaTecnica_ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.DropColumn(
                name: "ComprovanteCompraId",
                table: "EntradaAssistenciaTecnica");

            migrationBuilder.DropColumn(
                name: "NumeroComprovanteCompra",
                table: "EntradaAssistenciaTecnica");
        }
    }
}
