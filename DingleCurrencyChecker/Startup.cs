using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingleCurrencyChecker.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DingleCurrencyChecker
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
            services.AddMvc();
            services.AddCors(option=> {
                option.AddPolicy("AllowAllOrigins",
                       builder =>
                       {
                           builder.AllowAnyOrigin();
                       });
            });
            var settings = Configuration.GetSection(nameof(Config)).Get<Config>();

            services.AddTransient<CurrencyConverterService>();
            services.AddTransient<ICurrencySource, CurrencyLayerService>(c => new CurrencyLayerService(settings.CurrencyLayerKey));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowAllOrigins");
            }
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            

            app.UseMvc();
        }
    }
}
