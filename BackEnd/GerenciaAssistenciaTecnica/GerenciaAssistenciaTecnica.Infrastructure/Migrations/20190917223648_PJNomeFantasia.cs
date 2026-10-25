using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class PJNomeFantasia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_TipoEmpresa_TipoEmpresaId",
                table: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "TipoEmpresa");

            migrationBuilder.DropIndex(
                name: "IX_PessoaJuridica_TipoEmpresaId",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "TipoEmpresaId",
                table: "PessoaJuridica");

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "PessoaJuridica",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "PessoaJuridica");

            migrationBuilder.AddColumn<int>(
                name: "TipoEmpresaId",
                table: "PessoaJuridica",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpresa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_TipoEmpresaId",
                table: "PessoaJuridica",
                column: "TipoEmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_TipoEmpresa_TipoEmpresaId",
                table: "PessoaJuridica",
                column: "TipoEmpresaId",
                principalTable: "TipoEmpresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
