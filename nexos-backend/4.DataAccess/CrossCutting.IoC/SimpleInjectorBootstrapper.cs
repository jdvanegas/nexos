using Application.IoC;
using DataAccess;
using DataAccess.Nexos;
using Domain.EntityMapper.IoC;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace CrossCutting.IoC
{
  public static class SimpleInjectorBootstrapper
  {
    public static void RegisterDependencies(this Container container)
    {
      container.Register<DbContext, NexosContext>();

      container.RegisterNexosRepository();

      container.RegisterAutomapper();

      container.RegisterServices();
    }

    public static void RegisterDependenciesScoped(this Container container)
    {
      container.Register<DbContext, NexosContext>(Lifestyle.Scoped);

      container.RegisterNexosRepositoryScoped();

      container.RegisterAutomapperScoped();

      container.RegisterServicesScoped();
    }
  }
}