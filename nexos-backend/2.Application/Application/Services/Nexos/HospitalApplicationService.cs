using Application.Contracts.Nexos;
using Domain.Entities;
using Domain.Repository;
using Domain.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Nexos
{
  public class HospitalApplicationService : ApplicationService<Hospital>, IHospitalApplicationService
  {
    public HospitalApplicationService(IHospitalRepository repository) : base(repository)
    {
    }
  }
}