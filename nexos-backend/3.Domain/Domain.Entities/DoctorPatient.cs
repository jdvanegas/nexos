using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("DoctorPatient", Schema = "nexos")]
  public class DoctorPatient
  {
    [Key, ForeignKey("Doctor"), Column(Order = 1)]
    public long DoctorId { get; set; }

    [Key, ForeignKey("Patient"), Column(Order = 2)]
    public long PatientId { get; set; }

    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
  }
}