namespace OnMed.ViewModel.Patients;

public class PatientViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public DateOnly BirthDay { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsMale { get; set; }
    public string Region { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
