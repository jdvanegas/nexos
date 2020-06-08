using Domain.Entities;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Nexos.Repository
{
  public class DoctorPatientRepository : Repository<DoctorPatient>, IDoctorPatientRepository
  {
    public DoctorPatientRepository(DbContext dbContext, ILogger<Repository<DoctorPatient>> logger) : base(dbContext, logger)
    {
    }
  }
}