using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OracleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleAPI
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
            services.AddRazorPages();

            services.AddDbContext<OracleDBContext>(options =>
            options.UseOracle(
                "DATA SOURCE=(" +
                "DESCRIPTION=(" +
                "ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)" +
                "(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=xepdb1)))" +
                ";USER ID=HR; Password=hr;"
                 ,
                 b => b.MigrationsAssembly(typeof(OracleDBContext)
                 .Assembly.FullName)
                 

            ));
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//api routing
                endpoints.MapRazorPages();//mvc page
            });

           
        }
    }
}
