using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Nexos
{
  public interface IPatientApplicationService : IApplicationService<Patient>
  {
    IEnumerable<Domain.DataTransferObjects.Patient> List();

    Task<Domain.DataTransferObjects.Patient> GetById(long id);

    Task<OperationResult<Patient>> Edit(Domain.DataTransferObjects.Patient patient);

    Task<OperationResult<Patient>> Create(Domain.DataTransferObjects.Patient patient);
  }
}