using Application.Contracts.Nexos;
using Application.Services.Nexos;
using SimpleInjector;

namespace Application.IoC
{
  public static class SimpleInjectorBootstrapper
  {
    public static void RegisterServices(this Container container)
    {
      container.Register<IPatientApplicationService, PatientApplicationService>();
      container.Register<IDoctorApplicationService, DoctorApplicationService>();
      container.Register<IHospitalApplicationService, HospitalApplicationService>();
    }

    public static void RegisterServicesScoped(this Container container)
    {
      container.Register<IPatientApplicationService, PatientApplicationService>(Lifestyle.Scoped);
      container.Register<IDoctorApplicationService, DoctorApplicationService>(Lifestyle.Scoped);
      container.Register<IHospitalApplicationService, HospitalApplicationService>(Lifestyle.Scoped);
    }
  }
}