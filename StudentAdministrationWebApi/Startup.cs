using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StudentAdministrationWebApi.DAL.Data;
using StudentAdministrationWebApi.Swagger;
using Swashbuckle.AspNetCore.Swagger;

namespace StudentAdministrationWebApi
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContextPool<ApplicationDbContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("StudentAdministrationDb")));


            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Info
                {
                    Version = "v1.01",
                    Title = "Student Administration WebApi",
                    Description = "WebApi for a Student Administration System, built as an example project.",
                    Contact = new Contact()
                    {
                        Name = "Niels",
                        Email = "niels.pilgaard@hotmail.com"
                    }
                });
                //Used for uploading files through Swagger, has no feasable uses at the moment.
                config.OperationFilter<FormFileSwaggerFilter>();
            });

            services.AddCors();
            services.AddLogging(l => l.AddConsole());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging")); //log levels set in your configuration
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHsts();

            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder =>
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyOrigin()
                );

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Administration WebApi - v1");
            });

            app.UseStatusCodePages("text/plain", "Status code page, status code: {0}");
        }
    }
}
