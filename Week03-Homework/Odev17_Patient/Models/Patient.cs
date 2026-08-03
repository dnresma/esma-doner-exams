using System;

namespace Odev17_Patient.Models;

public class Patient
{
    public Patient(int patientId, string fullName, DateTime birthDate, string bloodType)
    {
        PatientId = patientId;
        FullName = fullName;
        BirthDate = birthDate;
        BloodType = bloodType;
    }
    
        
    public int PatientId { get; set; }
    public string? FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? BloodType { get; set; }
}

