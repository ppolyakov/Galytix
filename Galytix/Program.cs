using Galytix.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Galytix
{
    public class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        options.ListenAnyIP(9091);
                    });

                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddSingleton<CountryGwpDataStore>();
                        services.AddSingleton<ICountryGwpRepository, CsvCountryGwpRepository>();
                        services.AddSingleton<ICsvParser, CsvParser>();
                        services.AddControllers()
                                   .AddNewtonsoftJson();
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gatylix API", Version = "v1" });
                        });
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CountryGwp API V1");
                        });

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.MapGet("/", async context =>
                            {
                                await context.Response.WriteAsync("Self-hosted web API for Galytix!");
                            });
                        });
                    });
                })
                .Build();

            host.Run();
        }
    }
}
