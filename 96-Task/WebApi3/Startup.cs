using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApi3 {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddLogging(config =>
            {
                // clear out default configuration
                config.ClearProviders();
            });
            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddTransient<IDbConnection>((sp) => new SqlConnection("Server=LI-598;Database=test;User Id=sa;Password=YourStrong@Passw0rd;"));

            services.AddHttpClient();
            services.AddControllers ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseRouting ();

            // app.UseAuthorization();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}