using AutoMapper;
using System.Linq;

namespace Domain.EntityMapper
{
  public class NexosProfile : Profile
  {
    public NexosProfile()
    {
      CreateMap<Entities.Hospital, DataTransferObjects.Hospital>();
      CreateMap<Entities.Hospital, DataTransferObjects.Hospital>().ReverseMap();
      CreateMap<Entities.Doctor, DataTransferObjects.Doctor>();
      CreateMap<Entities.Doctor, DataTransferObjects.Doctor>().ReverseMap()
        .ForMember(dest => dest.HospitalId, opt => opt.MapFrom(src => src.Hospital.Id))
        .ForMember(dest => dest.Hospital, opt => opt.Ignore())
        ;
      CreateMap<Entities.Patient, DataTransferObjects.Patient>()
        .ForMember(dest => dest.Doctors, opt =>
        opt.MapFrom(src => src.DoctorPatients.Select(d => new DataTransferObjects.Doctor
        {
          Id = d.Doctor.Id,
          Name = d.Doctor.Name,
          LastName = d.Doctor.LastName,
        })))
        ;
      CreateMap<Entities.Patient, DataTransferObjects.Patient>().ReverseMap()
         .ForMember(dest => dest.DoctorPatients, opt => opt.Ignore())
         ;
    }
  }
}