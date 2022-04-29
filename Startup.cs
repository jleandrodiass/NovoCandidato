using System.Text;
using Microsoft.EntityFrameworkCore;
using Candidatos.Buseness.Interfaces;
using Candidatos.repositorio;
using Candidatos.repositorio.Buseness;
using Candidatos.repositorio.Interfaces;

namespace Selection_Register
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();

             services.AddScoped<ICandidato_Bs, CandidatoBus>();
             services.AddScoped<ICandidato_Rp, CandidatoRp>();
           
       }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}