using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;





namespace nartyy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
   

            // other service configurations
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
     
            
            app.UseStaticFiles();

            // other middleware configurations
        }
    }
}

