using AutoMapper;
using citas_medicas.net.Models;
using citas_medicas.net.Repository;
using citas_medicas.net.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citas_medicas.net
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"]));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200/",
                                                          "https://localhost:4200/")
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "citasMedicas.net", Version = "v1" });
            });

            /*
             * Mappeo los DTOs con el modelo.
             */
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<Mappeando>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper); //el mapper me interesa Singleton

            //services.AddSingleton<IRepositorio<Usuario>, RepositorioUsuario<Usuario>>();
            //Los servicios me interesa Scope; cada transacci?n se crea un nuevo scope.
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<ICitaService, CitaService>();
            services.AddScoped<IDiagnosticoService, DiagnosticoService>();

            //inicio los servicios de repositorio
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioCita<>));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioDiagnostico<>));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioMedico<>));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioPaciente<>));
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioUsuario<>));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "citasMedicas.net v1"));
            }

            app.UseCors(opt =>
            {
                opt.WithOrigins("http://localhost:4200");
                opt.AllowAnyMethod();
                opt.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
