using System;
using ControlePessoal.Domain.Handlers;
using ControlePessoal.Domain.Repositories;
using ControlePessoal.Infrastructure.Contexts;
using ControlePessoal.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ControlePessoal.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services.AddMvc()
                .AddNewtonsoftJson();

            //services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure(
            //            maxRetryCount: 10,
            //            maxRetryDelay: TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null);
            //    }
            //    ));

            services.AddDbContext<DataContext>(x => x.UseMySql(Configuration.GetConnectionString("MySql"),
                ServerVersion.AutoDetect(Configuration.GetConnectionString("MySql")),
                mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }
                ));

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<UsuarioHandler, UsuarioHandler>();

            services.AddTransient<IPontoRepository, PontoRepository>();
            services.AddTransient<PontoHandler, PontoHandler>();

            services.AddTransient<IAusenciaRepository, AusenciaRepository>();
            services.AddTransient<AusenciaHandler, AusenciaHandler>();

            services.AddTransient<ISalarioRepository, SalarioRepository>();
            services.AddTransient<SalarioHandler, SalarioHandler>();

            services.AddTransient<IHoleriteRepository, HoleriteRepository>();
            services.AddTransient<HoleriteHandler, HoleriteHandler>();

            services.AddTransient<IParametroUsuarioRepository, ParametroUsuarioRepository>();

            services.AddTransient<ITabelaRepository, TabelaRepository>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Authority = "https://securetoken.google.com/controlepessoal-api";
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/controlepessoal-api",
                        ValidateAudience = true,
                        ValidAudience = "controlepessoal-api",
                        ValidateLifetime = true
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlePessoal.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControlePessoal.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
