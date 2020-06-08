using Domain.Entities;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Nexos.Repository
{
  public class HospitalRepository : Repository<Hospital>, IHospitalRepository
  {
    public HospitalRepository(DbContext dbContext, ILogger<Repository<Hospital>> logger) : base(dbContext, logger)
    {
    }
  }
}