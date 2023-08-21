﻿namespace OnMed.ViewModel.Doctors;

public class DoctorViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public DateOnly BirthDay { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsMale { get; set; }
    public string Degree { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public double AppointmentMoney { get; set; }
    public int StarCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}