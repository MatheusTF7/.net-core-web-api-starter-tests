using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjetoWebVale.Models;
using Swashbuckle.AspNetCore.Swagger;
using Pomelo.EntityFrameworkCore.MySql;

namespace ProjetoWebVale
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
            // using Microsoft.EntityFrameworkCore;
            services.AddDbContext<ProjetoWebValeDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMvc();

            services.AddMvc().AddJsonOptions(
               options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Projeto Web Vale Livre",
                    Description = "A simple example ASP.NET Core Web API with Entity Framwork Core using MySql. This Web API manages tasks associated with an account.",
                    TermsOfService = "https://github.com/MatheusTF7/ProjetoWebVale/blob/master/LICENSE",
                    Contact = new Contact
                    {
                        Name = "Matheus Gurgel",
                        Email = "matheuskillua77@gmail.com",
                        Url = "https://github.com/MatheusTF7/ProjetoWebVale",
                    },
                    License = new License
                    {
                        Name = "Use under MIT license",
                        Url = "https://github.com/MatheusTF7/ProjetoWebVale/blob/master/LICENSE",
                    }
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseCors(
                options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
