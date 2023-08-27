namespace OnMed.Dtos.ForgotPassword;

public class UpdatePasswordDto
{
    public string PhoneNumber { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;
}
