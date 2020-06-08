using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("Hospital", Schema = "nexos")]
  public class Hospital
  {
    public Hospital()
    {
      Doctors = new HashSet<Doctor>();
    }

    [Required, Key]
    public long Id { get; set; }

    public string Name { get; set; }
    public virtual IEnumerable<Doctor> Doctors { get; set; }
  }
}