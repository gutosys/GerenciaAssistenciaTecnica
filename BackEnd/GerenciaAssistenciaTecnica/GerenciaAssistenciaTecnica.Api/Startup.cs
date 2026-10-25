using GerenciaAssistenciaTecnica.Api.Models;
using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Api.Repositories.Abstract;
using GerenciaAssistenciaTecnica.Api.Repositories.Concrete;
using GerenciaAssistenciaTecnica.Api.Services;
using GerenciaAssistenciaTecnica.Api.Services.Abstract;
using GerenciaAssistenciaTecnica.Api.Services.Concrete;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System;
using System.IO;
using System.Text;

namespace GerenciaAssistenciaTecnica.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string OrigensPermitidas = "OrigensPermitidas";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IRegimeTributarioRepository, RegimeTributarioRepository>();
            services.AddScoped<IRegimeTributarioService, RegimeTributarioService>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeComboService, CidadeComboService>();

            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();

            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            services.AddScoped<IMaquinaService, MaquinaService>();
            services.AddScoped<IMaquinaRepository, MaquinaRepository>();

            services.AddScoped<IMaquinaClienteService, MaquinaClienteService>();
            services.AddScoped<IMaquinaClienteRepository, MaquinaClienteRepository>();

            services.AddScoped<IComponenteService, ComponenteService>();
            services.AddScoped<IComponenteRepository, ComponenteRepository>();

            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();

            services.AddScoped<IEntradaAssistenciaTecnicaService, EntradaAssistenciaTecnicaService>();
            services.AddScoped<IEntradaAssistenciaTecnicaRepository, EntradaAssistenciaTecnicaRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IClienteAssociadoService, ClienteAssociadoService>();
            services.AddScoped<IClienteAssociadoRepository, ClienteAssociadoRepository>();

            services.AddScoped<IProblemaService, ProblemaService>();
            services.AddScoped<IProblemaRepository, ProblemaRepository>();

            services.AddScoped<ICorComboService, CorComboService>();
            services.AddScoped<ICorRepository, CorRepository>();

            services.AddScoped<IEtiquetaService, EtiquetaService>();
            services.AddScoped<IEtiquetaRepository, EtiquetaRepository>();

            services.AddScoped<IComprovanteCompraService, ComprovanteCompraService>();
            services.AddScoped<IComprovanteCompraRepository, ComprovanteCompraRepository>();

            services.AddScoped<IEntreguePorService, EntreguePorService>();
            services.AddScoped<IEntreguePorRepository, EntreguePorRepository>();
                        
            services.AddScoped<INumeroSerieService, NumeroSerieService>();
            services.AddScoped<INumeroSerieRepository, NumeroSerieRepository>();

            services.AddScoped<INSService, NSService>();
            services.AddScoped<INSRepository, NSRepository>();
            
            services.AddScoped<IAcessorioService, AcessorioService>();
            services.AddScoped<IAcessorioRepository, AcessorioRepository>();

            //services.AddScoped<IAcessorioAssistenciaService, AcessorioAssistenciaService>();
            //services.AddScoped<IAcessorioAssistenciaRepository, AcessorioAssistenciaRepository>();

            #region JWT
            // Get JWT Token Settings from JwtSettings.json file
            JwtSettings settings;
            settings = GetJwtSettings();
            // Create singleton of JwtSettings
            services.AddSingleton<JwtSettings>(settings);

            // Register Jwt as the Authentication service
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
              new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(settings.Key)),
                  ValidateIssuer = true,
                  ValidIssuer = settings.Issuer,

                  ValidateAudience = true,
                  ValidAudience = settings.Audience,

                  ValidateLifetime = true,
                  ClockSkew = TimeSpan.FromMinutes(
                         settings.MinutesToExpiration)
              };
            });



            //ADICIONANDO A POLÍTICA DE CLAIMS
            services.AddAuthorization(cfg =>
            {
                // NOTE: The claim type and value are case-sensitive
                cfg.AddPolicy("CanAccessTipoEmpresa", p => p.RequireClaim("CanAccessTipoEmpresa", "true"));
                cfg.AddPolicy("CanAccessRegimeTributario", p => p.RequireClaim("CanAccessRegimeTributario", "true"));
            });


            #endregion






            services.AddDbContext<GerenciaAssistenciaTecnicaContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("GerenciaAssistenciaTecnicaConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(OrigensPermitidas,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "https://boxersoldasweb.azurewebsites.net",
                                        "https://boxersoldas.azurewebsites.net/api/security/login")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciaAssistenciaTecnica API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors(OrigensPermitidas);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });


            app.UseAuthentication();
            app.UseAuthorization();

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciaAssistenciaTecnica v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings();

            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience = Configuration["JwtSettings:audience"];
            settings.Issuer = Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration =
             Convert.ToInt32(
                Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}
