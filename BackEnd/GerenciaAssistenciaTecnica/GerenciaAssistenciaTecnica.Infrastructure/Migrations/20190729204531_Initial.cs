using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciaAssistenciaTecnica.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    PrecoCompra = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    PrecoVendaAutorizada = table.Column<decimal>(type: "decimal(19, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntradaAssistenciaTecnicaStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaAssistenciaTecnicaStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    UF = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 30, nullable: true),
                    Celular = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    Modelo = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegimeTributario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimeTributario", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 250, nullable: false),
                    Password = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    ClaimId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 250, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponenteId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    QuantidadeMinima = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(maxLength: 250, nullable: true),
                    Bairro = table.Column<string>(maxLength: 150, nullable: true),
                    Numero = table.Column<string>(maxLength: 30, nullable: true),
                    Cep = table.Column<string>(maxLength: 30, nullable: true),
                    CidadeId = table.Column<int>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 30, nullable: true),
                    Celular = table.Column<string>(maxLength: 30, nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    TipoPessoa = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    MaquinaId = table.Column<int>(nullable: false),
                    NumeroSerie = table.Column<string>(maxLength: 50, nullable: true),
                    DataInicioGarantia = table.Column<DateTime>(nullable: true),
                    DataFimGarantia = table.Column<DateTime>(nullable: true),
                    TemGarantia = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaquinaCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaquinaCliente_Maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 400, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    IE = table.Column<string>(maxLength: 200, nullable: false),
                    TipoEmpresaId = table.Column<int>(nullable: false),
                    RegimeTributarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_RegimeTributario_RegimeTributarioId",
                        column: x => x.RegimeTributarioId,
                        principalTable: "RegimeTributario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_TipoEmpresa_TipoEmpresaId",
                        column: x => x.TipoEmpresaId,
                        principalTable: "TipoEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteAssociado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 400, nullable: false),
                    PessoaJuridicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteAssociado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteAssociado_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradaAssistenciaTecnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaFisicaId = table.Column<int>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true),
                    ClienteAssociadoId = table.Column<int>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: false),
                    NumeroRemessa = table.Column<string>(maxLength: 250, nullable: false),
                    NumeroNF = table.Column<string>(maxLength: 250, nullable: false),
                    MaquinaId = table.Column<int>(nullable: false),
                    NumeroSerie = table.Column<string>(maxLength: 250, nullable: false),
                    Acessorios = table.Column<string>(maxLength: 500, nullable: false),
                    EntradaAssistenciaStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaAssistenciaTecnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_ClienteAssociado_ClienteAssociadoId",
                        column: x => x.ClienteAssociadoId,
                        principalTable: "ClienteAssociado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_EntradaAssistenciaTecnicaStatus_EntradaAssistenciaStatusId",
                        column: x => x.EntradaAssistenciaStatusId,
                        principalTable: "EntradaAssistenciaTecnicaStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_Maquina_MaquinaId",
                        column: x => x.MaquinaId,
                        principalTable: "Maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnica_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradaAssistenciaTecnicaDescricao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 2000, nullable: false),
                    EntradaAssistenciaStatusId = table.Column<int>(nullable: false),
                    EntradaAssistenciaTecnicaId = table.Column<int>(nullable: false),
                    DataGravacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaAssistenciaTecnicaDescricao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnicaDescricao_EntradaAssistenciaTecnicaStatus_EntradaAssistenciaStatusId",
                        column: x => x.EntradaAssistenciaStatusId,
                        principalTable: "EntradaAssistenciaTecnicaStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnicaDescricao_EntradaAssistenciaTecnica_EntradaAssistenciaTecnicaId",
                        column: x => x.EntradaAssistenciaTecnicaId,
                        principalTable: "EntradaAssistenciaTecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntradaAssistenciaTecnicaDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntradaAssistenciaTecnicaId = table.Column<int>(nullable: false),
                    File = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaAssistenciaTecnicaDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaAssistenciaTecnicaDocumento_EntradaAssistenciaTecnica_EntradaAssistenciaTecnicaId",
                        column: x => x.EntradaAssistenciaTecnicaId,
                        principalTable: "EntradaAssistenciaTecnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteAssociado_PessoaJuridicaId",
                table: "ClienteAssociado",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EstadoId",
                table: "Endereco",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_ClienteAssociadoId",
                table: "EntradaAssistenciaTecnica",
                column: "ClienteAssociadoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_EntradaAssistenciaStatusId",
                table: "EntradaAssistenciaTecnica",
                column: "EntradaAssistenciaStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_FuncionarioId",
                table: "EntradaAssistenciaTecnica",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_MaquinaId",
                table: "EntradaAssistenciaTecnica",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_PessoaFisicaId",
                table: "EntradaAssistenciaTecnica",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnica_PessoaJuridicaId",
                table: "EntradaAssistenciaTecnica",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnicaDescricao_EntradaAssistenciaStatusId",
                table: "EntradaAssistenciaTecnicaDescricao",
                column: "EntradaAssistenciaStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnicaDescricao_EntradaAssistenciaTecnicaId",
                table: "EntradaAssistenciaTecnicaDescricao",
                column: "EntradaAssistenciaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaAssistenciaTecnicaDocumento_EntradaAssistenciaTecnicaId",
                table: "EntradaAssistenciaTecnicaDocumento",
                column: "EntradaAssistenciaTecnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ComponenteId",
                table: "Estoque",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinaCliente_ClienteId",
                table: "MaquinaCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinaCliente_MaquinaId",
                table: "MaquinaCliente",
                column: "MaquinaId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_ClienteId",
                table: "PessoaFisica",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_ClienteId",
                table: "PessoaJuridica",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_RegimeTributarioId",
                table: "PessoaJuridica",
                column: "RegimeTributarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_TipoEmpresaId",
                table: "PessoaJuridica",
                column: "TipoEmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "EntradaAssistenciaTecnicaDescricao");

            migrationBuilder.DropTable(
                name: "EntradaAssistenciaTecnicaDocumento");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "MaquinaCliente");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "EntradaAssistenciaTecnica");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "ClienteAssociado");

            migrationBuilder.DropTable(
                name: "EntradaAssistenciaTecnicaStatus");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "RegimeTributario");

            migrationBuilder.DropTable(
                name: "TipoEmpresa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
