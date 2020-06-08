using AutoMapper;
using CrossCutting.IoC;
using Domain.EntityMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace NexosApi
{
  public class Startup
  {
    private readonly Container _container = new Container();

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddControllers(options =>
      {
        options.RespectBrowserAcceptHeader = true; // false by default
      });
      services.AddLogging();
      IntegrateSimpleInjector(services);
      services.AddAutoMapper(c => c.AddProfile<NexosProfile>(), typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddFile("Logs/nexos-{Date}.log");

      InitializeContainer();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", async context =>
        {
          context.Response.ContentType = "application/json";
          await context.Response.WriteAsync(@"{""name"":"" Nexos API"", ""status"": ""Working""}");
        });
        endpoints.MapControllers();
      });

      _container.Verify();
    }

    private void IntegrateSimpleInjector(IServiceCollection services)
    {
      _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddSingleton<IControllerActivator>(
          new SimpleInjectorControllerActivator(_container));
      services.AddSingleton<IViewComponentActivator>(
          new SimpleInjectorViewComponentActivator(_container));

      services.AddSimpleInjector(_container, o =>
      {
        o.AddAspNetCore().AddControllerActivation();
        o.AddAspNetCore().AddViewComponentActivation();
        o.AutoCrossWireFrameworkComponents = true;
        o.AddLogging();
      });
      services.UseSimpleInjectorAspNetRequestScoping(_container);
    }

    private void InitializeContainer()
    {
      // Add application services. For instance:
      _container.RegisterDependenciesScoped();
    }
  }
}