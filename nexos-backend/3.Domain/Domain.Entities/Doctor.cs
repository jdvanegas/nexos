using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("Doctor", Schema = "nexos")]
  public class Doctor
  {
    public Doctor()
    {
      DoctorPatients = new HashSet<DoctorPatient>();
    }

    [Required, Key]
    public long Id { get; set; }

    [Required, ForeignKey("Hospital")]
    public long HospitalId { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string CredentialNumber { get; set; }
    public Hospital Hospital { get; set; }
    public virtual IEnumerable<DoctorPatient> DoctorPatients { get; set; }
  }
}