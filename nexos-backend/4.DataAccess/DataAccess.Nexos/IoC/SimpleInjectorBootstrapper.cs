using DataAccess.Nexos.Repository;
using Domain.Repository.Contracts;
using SimpleInjector;

namespace DataAccess.Nexos
{
  public static class SimpleInjectorBootstrapper
  {
    public static void RegisterNexosRepository(this Container container)
    {
      container.Register<IPatientRepository, PatientRepository>();
      container.Register<IDoctorRepository, DoctorRepository>();
      container.Register<IHospitalRepository, HospitalRepository>();
      container.Register<IDoctorPatientRepository, DoctorPatientRepository>();
    }

    public static void RegisterNexosRepositoryScoped(this Container container)
    {
      container.Register<IPatientRepository, PatientRepository>(Lifestyle.Scoped);
      container.Register<IDoctorRepository, DoctorRepository>(Lifestyle.Scoped);
      container.Register<IHospitalRepository, HospitalRepository>(Lifestyle.Scoped);
      container.Register<IDoctorPatientRepository, DoctorPatientRepository>(Lifestyle.Scoped);
    }
  }
}