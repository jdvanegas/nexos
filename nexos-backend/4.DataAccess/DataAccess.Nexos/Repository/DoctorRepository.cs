using Domain.Entities;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Nexos.Repository
{
  public class DoctorRepository : Repository<Doctor>, IDoctorRepository
  {
    public DoctorRepository(DbContext dbContext, ILogger<Repository<Doctor>> logger) : base(dbContext, logger)
    {
    }
  }
}