﻿using System;
using System.Collections.Generic;

namespace Domain.DataTransferObjects
{
  public class Doctor
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string CredentialNumber { get; set; }
    public Hospital Hospital { get; set; }
  }
}