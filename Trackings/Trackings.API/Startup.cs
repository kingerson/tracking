using Trackings.API.Infrastructure.AutofacModules;
using Trackings.Service;
using Trackings.Domain.Exceptions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealPlaza.Libs.Core;
using System;

namespace Trackings.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors()
                .AddHttpContextAccessor()
                .AddCustomMvc<Startup, TrackingsBaseException>()
                .AddCustomAuthentication(_configuration)
                .AddSwaggerDoc(_configuration)
                .AddBackgroundTasks();

            services.AddHttpClient<ISomeService, SomeService>().AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            var container = new ContainerBuilder();
                container.Populate(services);
                container.RegisterModule(new ApplicationModule(_configuration["ConnectionString"]));
                container.RegisterModule(new MediatorModule());

            return new AutofacServiceProvider(container.Build());
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            UseTelemetryFilter(app);
            app.UseAllCors();
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDoc(_configuration);
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }
            app.UseMvc();
        }
        private void UseTelemetryFilter(IApplicationBuilder app)
        {
            var configuration = app.ApplicationServices.GetService<TelemetryConfiguration>();
            configuration.TelemetryProcessorChainBuilder.Use(next => new TelemetryProcessor(next));
            configuration.TelemetryProcessorChainBuilder.Build();
        }
    }
}
