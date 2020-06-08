using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Domain.Entities;

namespace DataAccess.Nexos.Repository
{
  public class PatientRepository : Repository<Patient>, IPatientRepository
  {
    public PatientRepository(DbContext dbContext, ILogger<Repository<Patient>> logger)
      : base(dbContext, logger)
    {
    }
  }
}