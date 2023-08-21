using System.ComponentModel;

namespace OnMed.ViewModel.Hospitals;

public class HospitalViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LegalName { get; set; } = string.Empty;
    public string BrandImagePath { get; set; } = string.Empty;
    public string AdministratorPhoneNumber { get; set; } = string.Empty;
    public string FaxPhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateOnly LicenseGivenDate { get; set; }
    public string LegalRegisterNumber { get; set; } = string.Empty;
    public DateOnly LegalRegisterNumberGivenDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
