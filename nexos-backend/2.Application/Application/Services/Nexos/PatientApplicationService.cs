using Application.Contracts.Nexos;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Application.Services.Nexos
{
  public class PatientApplicationService : ApplicationService<Domain.Entities.Patient>, IPatientApplicationService
  {
    private readonly IDoctorPatientRepository _doctorPatientRepository;
    private readonly IMapper _mapper;

    public PatientApplicationService(IDoctorPatientRepository doctorPatientRepository, IMapper mapper,
      IPatientRepository repository) : base(repository)
    {
      _doctorPatientRepository = doctorPatientRepository;
      _mapper = mapper;
    }

    public async Task<Domain.DataTransferObjects.Patient> GetById(long id)
    {
      var data = await Queryable().Include("DoctorPatients.Doctor").FirstOrDefaultAsync(x => x.Id == id);
      var patient = new Domain.DataTransferObjects.Patient
      {
        Id = data.Id,
        Name = data.Name,
        LastName = data.LastName,
        SecurityNumber = data.SecurityNumber,
        PostalCode = data.PostalCode,
        Phone = data.Phone,
        Doctors = data.DoctorPatients.Select(y => new Domain.DataTransferObjects.Doctor
        {
          Id = y.DoctorId,
          Name = y.Doctor.Name,
          LastName = y.Doctor.LastName
        })
      };

      return patient;
    }

    public IEnumerable<Domain.DataTransferObjects.Patient> List()
    {
      return Queryable().Include("DoctorPatients.Doctor").Select(x => new Domain.DataTransferObjects.Patient
      {
        Id = x.Id,
        Name = x.Name,
        LastName = x.LastName,
        SecurityNumber = x.SecurityNumber,
        PostalCode = x.PostalCode,
        Phone = x.Phone,
        Doctors = x.DoctorPatients.Select(y => new Domain.DataTransferObjects.Doctor
        {
          Id = y.DoctorId,
          Name = y.Doctor.Name,
          LastName = y.Doctor.LastName
        })
      });
    }

    public async Task<OperationResult<Domain.Entities.Patient>> Edit(Domain.DataTransferObjects.Patient patient)
    {
      var entity = _mapper.Map<Patient>(patient);
      await _doctorPatientRepository.Remove(x => x.PatientId == patient.Id);
      var result = await Update(entity);
      if (result.Status)
      {
        foreach (var doctor in patient.Doctors)
        {
          await _doctorPatientRepository.Create(new DoctorPatient { DoctorId = doctor.Id, PatientId = entity.Id });
        }
      }
      return result;
    }

    public async Task<OperationResult<Domain.Entities.Patient>> Create(Domain.DataTransferObjects.Patient patient)
    {
      var entity = _mapper.Map<Patient>(patient);
      var result = await Create(entity);
      if (result.Status)
      {
        foreach (var doctor in patient.Doctors)
        {
          await _doctorPatientRepository.Create(new DoctorPatient { DoctorId = doctor.Id, PatientId = entity.Id });
        }
      }
      return result;
    }
  }
}