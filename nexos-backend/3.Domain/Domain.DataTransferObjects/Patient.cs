using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataTransferObjects
{
  public class Patient
  {
    public long? Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string SecurityNumber { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }

    public IEnumerable<Doctor> Doctors { get; set; } = new List<Doctor>();
  }
}