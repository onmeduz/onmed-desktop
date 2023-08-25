namespace OnMed.Dtos.Doctors;

public class DoctorUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string MiddleName { get; set; } = String.Empty;
    public string BirthDay { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public bool IsMale { get; set; }
    public string Image { get; set; } = default!;
    public string Region { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public double AppointmentMoney { get; set; }
    public string Degree { get; set; } = string.Empty;
}
