using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Smartpark.Repository;
using Smartpark.Repository.Context;
using Smartpark.Repository.Implementacion;
using Smartpark.Service.Implementacion;
using Smartpark.Service;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;


namespace Smartpark.Api
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
            services.AddDbContext<ApplicationDbContext>(options=>
            
            
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
             services.AddTransient<IServicioRepository, ServicioRepository>();
            services.AddTransient<IServicioService, ServicioService>();

            services.AddTransient<IAdministradorRepository, AdministradorRepository>();
            services.AddTransient<IAdministradorService, AdministradorService>();

            services.AddTransient<IParkingRepository, ParkingRepository>();
            services.AddTransient<IParkingService, ParkingService>();
            
            services.AddTransient<IIngresoRepository, IngresoRepository>();
            services.AddTransient<IIngresoService, IngresoService>();

            services.AddTransient<IEspacioRepository, EspacioRepository>();
            services.AddTransient<IEspacioService, EspacioService>();

            services.AddTransient<ITarifaRepository, TarifaRepository>();
            services.AddTransient<ITarifaService, TarifaService>();

            services.AddTransient<ICajeroRepository, CajeroRepository>();
            services.AddTransient<ICajeroService, CajeroService>();

            services.AddTransient<IIngresoServicioRepository, IngresoServicioRepository>();
            services.AddTransient<IIngresoServicioService, IngresoServicioService>();

            services.AddTransient<IComprobanteRepository, ComprobanteRepository>();
            services.AddTransient<IComprobanteService, ComprobanteService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = 
                               Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
           
              services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                                    new Info
                                    {
                                        Title = SwaggerConfiguration.DocInfoTitle,
                                        Version = SwaggerConfiguration.DocInfoVersion,
                                        Description = SwaggerConfiguration.DocInfoDescription,
                                        Contact = contact
                                    }
                                    );
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Todos");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
