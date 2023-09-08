namespace OnMed.ViewModel.Admin;

public class AdminViewModel
{
    public long AdminId { get; set; }
    public List<long> HospitalBranchIds { get; set; } = new List<long>();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public List<string> HospitalNames { get; set; } = new List<string>();
    public string RegistrationDate { get; set; } = string.Empty;

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}
