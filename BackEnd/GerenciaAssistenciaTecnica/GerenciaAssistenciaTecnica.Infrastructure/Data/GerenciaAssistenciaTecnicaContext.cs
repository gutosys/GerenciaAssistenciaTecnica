
using GerenciaAssistenciaTecnica.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace GerenciaAssistenciaTecnica.Infrastructure.Data
{
    public class GerenciaAssistenciaTecnicaContext : DbContext
    {
        public GerenciaAssistenciaTecnicaContext(DbContextOptions<GerenciaAssistenciaTecnicaContext> options) : base(options)
        {
        }
        public DbSet<Acessorio> Acessorios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<RegimeTributario> RegimeTributarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<MaquinaCliente> MaquinaClientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<EntradaAssistenciaTecnica> EntradaAssistenciaTecnicas { get; set; }
        public DbSet<EntradaAssistenciaStatus> EntradaAssistenciaStatus { get; set; }
        public DbSet<EntradaAssistenciaDocumento> EntradaAssistenciaDocumentos { get; set; }
        public DbSet<EntradaAssistenciaDescricao> EntradaAssistenciaDescricoes { get; set; }
        public DbSet<EntradaAssistenciaAcessorio> EntradaAssistenciaAcessorios { get; set; }
        public DbSet<ClienteAssociado> ClienteAssociados { get; set; }

        public DbSet<Problema> Problemas { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }

        public DbSet<ComprovanteCompra> ComprovanteCompras { get; set; }

        public DbSet<EntreguePor> EntreguePor { get; set; }

        //public DbSet<AcessorioMaquinaAssistencia> AcessorioMaquinaAssistencias { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserClaim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            builder.Entity<Estado>(ConfigureEstado);
            builder.Entity<RegimeTributario>(ConfigureRegimeTributario);
            builder.Entity<Cidade>(ConfigureCidade);
            builder.Entity<Endereco>(ConfigureEndereco);

            builder.Entity<Acessorio>(ConfigureAcessorio);

            builder.Entity<Cliente>(ConfigureCliente);
            builder.Entity<PessoaFisica>(ConfigurePessoaFisica);
            builder.Entity<PessoaJuridica>(ConfigurePessoaJuridica);
            builder.Entity<ClienteAssociado>(ConfigureClienteAssociado);

            builder.Entity<Maquina>(ConfigureMaquina);
            builder.Entity<MaquinaCliente>(ConfigureMaquinaCliente);

            builder.Entity<Funcionario>(ConfigureFuncionario);

            builder.Entity<Categoria>(ConfigureCategoria);

            builder.Entity<Componente>(ConfigureComponente);
            builder.Entity<Estoque>(ConfigureEstoque);

            //builder.Entity<AcessorioMaquinaAssistencia>(ConfigureEntradaAcessorioMaquinaAssistencia);

            builder.Entity<EntradaAssistenciaTecnica>(ConfigureEntradaAssistenciaTecnica);
            builder.Entity<EntradaAssistenciaDocumento>(ConfigureEntradaAssistenciaDocumento);
            builder.Entity<EntradaAssistenciaDescricao>(ConfigureEntradaAssistenciaDescricao);

            builder.Entity<EntradaAssistenciaStatus>(ConfigureEntradaAssistenciaTecnicaStatus);
            builder.Entity<EntradaAssistenciaAcessorio>(ConfigureEntradaAssistenciaAcessorio);            

            builder.Entity<Problema>(ConfigureProblema);

            builder.Entity<Cor>(ConfigureCor);
            builder.Entity<Etiqueta>(ConfigureEtiqueta);
            builder.Entity<ComprovanteCompra>(ConfigureComprovanteCompra);
            builder.Entity<EntreguePor>(ConfigureEntreguePor);

            builder.Entity<AppUser>(ConfigureAppUser);
            builder.Entity<AppUserClaim>(ConfigureAppUserClaim);



        }

        private void ConfigureClienteAssociado(EntityTypeBuilder<ClienteAssociado> builder)
        {
            builder.ToTable("ClienteAssociado");

            builder.Property(te => te.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(ci => ci.Nome)
                    .IsRequired(true)
                    .HasMaxLength(400);

            builder.Property(ci => ci.Telefone)
                   .IsRequired(true)
                   .HasMaxLength(50);

            builder
                .HasOne(e => e.PessoaJuridica);
        }

        private void ConfigureCategoria(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureProblema(EntityTypeBuilder<Problema> builder)
        {
            builder.ToTable("Problema");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureCor(EntityTypeBuilder<Cor> builder)
        {
            builder.ToTable("Cor");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.ColorHex)
                .IsRequired(true)
                .HasMaxLength(50);
        }

        private void ConfigureEtiqueta(EntityTypeBuilder<Etiqueta> builder)
        {
            builder.ToTable("Etiqueta");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder
               .HasOne(e => e.Cor);
        }

        private void ConfigureComprovanteCompra(EntityTypeBuilder<ComprovanteCompra> builder)
        {
            builder.ToTable("ComprovanteCompra");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureEntreguePor(EntityTypeBuilder<EntreguePor> builder)
        {
            builder.ToTable("EntreguePor");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureAppUser(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("User");

            builder.Property(te => te.UserId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.UserName)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.Password)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureAppUserClaim(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.ToTable("UserClaim");

            builder.Property(te => te.ClaimId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(te => te.UserId)
                .IsRequired();

            builder.Property(ci => ci.ClaimType)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.ClaimValue)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureAcessorio(EntityTypeBuilder<Acessorio> builder)
        {
            builder.ToTable("Acessorio");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureEstado(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.UF)
                .IsRequired(true)
                .HasMaxLength(2);
        }

        private void ConfigureRegimeTributario(EntityTypeBuilder<RegimeTributario> builder)
        {
            builder.ToTable("RegimeTributario");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);
        }

        private void ConfigureCidade(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder
                .HasOne(e => e.Estado)
                .WithMany(c => c.Cidades);
        }

        private void ConfigureComponente(EntityTypeBuilder<Componente> builder)
        {
            builder.ToTable("Componente");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Nome)
               .IsRequired(true)
               .HasMaxLength(250);

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.PrecoCompra)
                .IsRequired(true)
                .HasColumnType("decimal(19, 4)");

            builder.Property(ci => ci.PrecoVenda)
                .IsRequired(true)
                .HasColumnType("decimal(19, 4)");

            builder.Property(ci => ci.PrecoVendaAutorizada)
                .IsRequired(true)
                .HasColumnType("decimal(19, 4)");
        }

        private void ConfigureEstoque(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("Estoque");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Quantidade)
               .IsRequired(true);

            builder.Property(ci => ci.QuantidadeMinima)
                .IsRequired(true);

            builder
               .HasOne(e => e.Componente);
        }


        //private void ConfigureEntradaAcessorioMaquinaAssistencia(EntityTypeBuilder<AcessorioMaquinaAssistencia> builder)
        //{
        //    builder.ToTable("AcessorioMaquinaAssistencia");

        //    builder.Property(te => te.Id)
        //        .ValueGeneratedOnAdd()
        //        .IsRequired();           

        //    builder
        //       .HasOne(e => e.EntradaAssistenciaTecnica)
        //       .WithMany(e => e.AcessorioMaquinaAssistenciaList);
        //}

        private void ConfigureEntradaAssistenciaTecnica(EntityTypeBuilder<EntradaAssistenciaTecnica> builder)
        {
            builder.ToTable("EntradaAssistenciaTecnica");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.NumeroRemessa)
               .HasMaxLength(250)
               .IsRequired(true);

            builder.Property(ci => ci.NumeroNF)
               .HasMaxLength(250)
               .IsRequired(true);

            builder.Property(ci => ci.NumeroComprovanteCompra)
              .HasMaxLength(250)
              .IsRequired(true);          

            builder.Property(ci => ci.NumeroSerie)
                .HasMaxLength(250)
                .IsRequired(true);

            builder.Property(ci => ci.NS)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(ci => ci.TrocaJaEfetuada)
            .HasDefaultValue(false)
            .IsRequired(true);

            builder.Property(ci => ci.NumeroProtocoloTroca)
            .HasMaxLength(100);

            builder.Property(ci => ci.CodigoRastreio)
            .HasMaxLength(100);

            builder.Property(ci => ci.Revenda);            

            builder
               .HasOne(e => e.PessoaFisica);

            builder
              .HasOne(e => e.PessoaJuridica);

            builder
              .HasOne(e => e.ClienteAssociado);

            builder
              .HasOne(e => e.Funcionario);

            builder
              .HasOne(e => e.Maquina);

            builder
              .HasOne(e => e.EntradaAssistenciaStatus);

            builder
              .HasOne(e => e.ComprovanteCompras);

            builder
             .HasOne(e => e.EntreguePor);
        }

        private void ConfigureEntradaAssistenciaTecnicaStatus(EntityTypeBuilder<EntradaAssistenciaStatus> builder)
        {
            builder.ToTable("EntradaAssistenciaTecnicaStatus");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
               .HasMaxLength(250)
               .IsRequired(true);
        }



        private void ConfigureEntradaAssistenciaDocumento(EntityTypeBuilder<EntradaAssistenciaDocumento> builder)
        {
            builder.ToTable("EntradaAssistenciaTecnicaDocumento");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.FileName)
                .IsRequired(true)
                .HasMaxLength(500);

            builder
                .HasOne(e => e.EntradaAssistenciaTecnica)
                .WithMany(c => c.EntradaAssistenciaDocumentos);
        }

        
        private void ConfigureEntradaAssistenciaAcessorio(EntityTypeBuilder<EntradaAssistenciaAcessorio> builder)
        {
            builder.ToTable("EntradaAssistenciaAcessorio");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();            

            builder
                .HasOne(e => e.EntradaAssistenciaTecnica)
                .WithMany(c => c.EntradaAssistenciaAcessorios);
        }


        private void ConfigureEntradaAssistenciaDescricao(EntityTypeBuilder<EntradaAssistenciaDescricao> builder)
        {
            builder.ToTable("EntradaAssistenciaTecnicaDescricao");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(2000);

            builder.Property(ci => ci.DataGravacao)
               .IsRequired(true);

            builder
                .HasOne(e => e.EntradaAssistenciaStatus);

            builder
                .HasOne(e => e.EntradaAssistenciaTecnica)
                .WithMany(c => c.EntradaAssistenciaDescricoes);
        }

        private void ConfigureEndereco(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Rua)
                    .HasMaxLength(250);

            builder.Property(ci => ci.Bairro)
                .HasMaxLength(150);

            builder.Property(ci => ci.Numero)
                .HasMaxLength(30);

            builder.Property(ci => ci.Cep)
               .HasMaxLength(30);

            builder
                .HasOne(e => e.Cidade);

            builder
                .HasOne(e => e.Estado);
        }

        private void ConfigureCliente(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Email)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(ci => ci.Telefone)
                    .HasMaxLength(30);

            builder.Property(ci => ci.Celular)
                    .HasMaxLength(30);

            builder.Property(ci => ci.TipoPessoa)
                    .IsRequired(true)
                    .HasMaxLength(1);

            builder
                .HasOne(e => e.Endereco);
        }

        private void ConfigurePessoaFisica(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("PessoaFisica");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Nome)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(ci => ci.Sobrenome)
                    .IsRequired(true)
                    .HasMaxLength(150);

            builder.Property(ci => ci.Cpf)
                    .IsRequired(true)
                    .HasMaxLength(11);

            builder.Property(ci => ci.Rg)
                    .IsRequired(true)
                    .HasMaxLength(20);

            builder
                .HasOne(e => e.Cliente);
        }

        private void ConfigureFuncionario(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Nome)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(ci => ci.Sobrenome)
                    .IsRequired(true)
                    .HasMaxLength(150);

            builder.Property(ci => ci.Cpf)
                    .IsRequired(true)
                    .HasMaxLength(11);

            builder.Property(ci => ci.Rg)
                    .IsRequired(true)
                    .HasMaxLength(20);

            builder.Property(ci => ci.Email)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder.Property(ci => ci.Telefone)
                    .HasMaxLength(30);

            builder.Property(ci => ci.Celular)
                    .HasMaxLength(30);
        }

        private void ConfigurePessoaJuridica(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("PessoaJuridica");

            builder.Property(te => te.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(ci => ci.RazaoSocial)
                    .IsRequired(true)
                    .HasMaxLength(400);

            builder.Property(ci => ci.NomeFantasia)
                    .IsRequired(true)
                    .HasMaxLength(400);

            builder.Property(ci => ci.Cnpj)
                    .IsRequired(true)
                    .HasMaxLength(14);

            builder.Property(ci => ci.IE)
                    .IsRequired(true)
                    .HasMaxLength(200);

            builder
                .HasOne(e => e.Cliente);            

            builder
                .HasOne(e => e.RegimeTributario);
        }

        private void ConfigureMaquina(EntityTypeBuilder<Maquina> builder)
        {
            builder.ToTable("Maquina");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ci => ci.Descricao)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.Modelo)
                .IsRequired(true)
                .HasMaxLength(200);
        }

        private void ConfigureMaquinaCliente(EntityTypeBuilder<MaquinaCliente> builder)
        {
            builder.ToTable("MaquinaCliente");

            builder.Property(te => te.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder
                .HasOne(e => e.Cliente);

            builder
                .HasOne(e => e.Maquina);

            builder.Property(ci => ci.NumeroSerie)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(ci => ci.DataInicioGarantia)
                .IsRequired(false);

            builder.Property(ci => ci.DataFimGarantia)
                .IsRequired(false);

            builder.Property(ci => ci.DataFimGarantia)
                .IsRequired(false);
        }
    }
}
