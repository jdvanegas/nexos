using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
  public class NexosContext : DbContext
  {
    private const string _connectionString = @"Server=.;Database=nexos;Trusted_Connection=True;";

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DoctorPatient>()
        .HasKey(x => new { x.DoctorId, x.PatientId });

      #region ModuleSeed

      modelBuilder.Entity<Hospital>().HasData(
        new Hospital
        {
          Id = 1,
          Name = "Hospital de Kennedy"
        },
        new Hospital
        {
          Id = 2,
          Name = "Hospital San Juan de Dios"
        },
        new Hospital
        {
          Id = 3,
          Name = "Hospital Meissen"
        }
      );

      modelBuilder.Entity<Doctor>().HasData(
        new Doctor
        {
          Id = 1,
          HospitalId = 1,
          Name = "Ariel",
          LastName = "Morales",
          CredentialNumber = "16220614"
        }
      );

      modelBuilder.Entity<Patient>().HasData(
        new Patient
        {
          Id = 1,
          Name = "Ariel",
          LastName = "Morales",
          SecurityNumber = "16220614",
          PostalCode = "654321",
          Phone = "3210987654"
        }
      );

      modelBuilder.Entity<DoctorPatient>().HasData(
        new DoctorPatient
        {
          PatientId = 1,
          DoctorId = 1
        }
      );

      #endregion ModuleSeed
    }
  }
}