using Application.Contracts.Nexos;
using Domain.Entities;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Nexos
{
  public class DoctorApplicationService : ApplicationService<Doctor>, IDoctorApplicationService
  {
    public DoctorApplicationService(IDoctorRepository repository) : base(repository)
    {
    }

    public async Task<Doctor> GetById(long id)
    {
      return await Queryable().Include(x => x.Hospital).FirstOrDefaultAsync(x => x.Id == id);
    }

    public IEnumerable<Doctor> List()
    {
      return Queryable().Include(x => x.Hospital);
    }
  }
}