using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace MyApp
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
            //services.AddMediatR(new IMediatRBuilder());

            services.AddTransient<IBenefitsService, BenefitsService>();
        }

        private void ConfigureHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://sua-api-externa.com/");
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        private void ConfigureBenefitsClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://sua-api-externa.com/benefits");
            client.Timeout = TimeSpan.FromSeconds(30);
        }


        private HttpClientHandler GetPrimaryHttpMessageHandler()
        {
            return new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseDefaultCredentials = true
                // Outras configurações...
            };
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configurações para ambientes de produção
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

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
