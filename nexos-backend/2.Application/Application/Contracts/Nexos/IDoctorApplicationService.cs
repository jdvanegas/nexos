using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Nexos
{
  public interface IDoctorApplicationService : IApplicationService<Doctor>
  {
    IEnumerable<Doctor> List();

    Task<Doctor> GetById(long id);
  }
}