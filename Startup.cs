using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.EntityFrameworkCore; 
using PersonService.Data;
 

namespace PersonService
{
    public class Startup
    {
        private static readonly string corsAllowAll = "AllowAll";
        const int swaggerPort = 6000;
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }


        public void ConfigureServices(IServiceCollection services)
        {
          /*  if (_env.IsProduction())
            {
                Console.WriteLine("--> Using SqlServer Db");
                services.AddDbContext<AppDbContext>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("PersonsConn")));
            }
            else
            {*/
                Console.WriteLine("--> Using mySQL Db");
                services.AddDbContext<AppDbContext>(opt =>
                      opt.UseMySQL(Configuration.GetConnectionString("PersonsConn")));


            // }

            services.AddCors(options =>
            {
                options.AddPolicy(name: corsAllowAll,
                   builder =>
                   {
                       builder.AllowAnyOrigin();
                       builder.AllowAnyMethod();
                       builder.AllowAnyHeader();

                   });
            });

            services.AddScoped<IPersonRepo, PersonRepo>();
 
       
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonService", Version = "v1" });
            });

          

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.MapWhen(context => context.Connection.LocalPort == swaggerPort, app =>
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonService v1"));
                });

            }
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(corsAllowAll);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
          

            });


            PrepDb.PrepPopulation(app, env.IsProduction());

        }
    }
}
