using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Contratos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositorio.Config;
using Repositorio.Contexto;
using Repositorio.Repository;

namespace WsPonto
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("configuracoes.json", optional: false, reloadOnChange: true);

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {   
            //services.AddMvc(option =>
            //{
            //    option.EnableEndpointRouting = false;
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddCors(c =>
            {
                c.AddPolicy("AlowsCors", options => {
                    options.AllowAnyOrigin()
                    .WithMethods("GET", "PUT", "POST", "DELETE")
                    .AllowAnyHeader();
                });
            });

            //services.AddControllers();

            //var conn = FactoryConnection.connection;
            //services.AddDbContext<PontoDbContext>(options =>
            //    options.UseSqlServer(conn).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddDbContext<PontoDbContext>();

            services.AddControllersWithViews();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<INivelAcessoRepository, NivelAcessoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            //services.AddTransient<RodarMigration>();

            services.AddControllers()
                    .AddNewtonsoftJson(opt =>
                        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var key = Encoding.ASCII.GetBytes(Token.Secret);

            services.AddAuthentication(Authentication =>
            {
                Authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(pX =>
            {
                pX.RequireHttpsMetadata = false;
                pX.SaveToken = true;
                pX.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(wag =>
            {
                wag.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Ponto",
                    Version = VersaoApi.VersaoWeb
                });
                wag.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                wag.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        }, new List<string>() }
                });

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
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PontoDbContext>();
                context.Database.EnsureCreated();
            }

            //app.UseMvc(option =>
            //{
            //    option.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" });
            //});
            app.UseSwaggerUI(swa =>
            {
                swa.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Ponto Online");
                swa.RoutePrefix = string.Empty;
            });

            app.UseSwagger();
            app.UseSwagger(v => v.SerializeAsV2 = true);



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //Migration
            //var serviceProv = app.ApplicationServices;
            //var rodarMigration = serviceProv.GetService<RodarMigration>();
            //rodarMigration.Executar();
            
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
