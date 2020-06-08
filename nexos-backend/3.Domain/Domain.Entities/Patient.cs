using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("Patient", Schema = "nexos")]
  public class Patient
  {
    public Patient()
    {
      DoctorPatients = new HashSet<DoctorPatient>();
    }

    [Required, Key]
    public long Id { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string SecurityNumber { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public virtual IEnumerable<DoctorPatient> DoctorPatients { get; set; }
  }
}