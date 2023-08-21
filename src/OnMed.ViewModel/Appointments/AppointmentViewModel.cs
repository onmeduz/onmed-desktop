namespace OnMed.ViewModel.Appointments;

public class AppointmentViewModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public long HospitalBranchId { get; set; }
    public DateOnly RegisterDate { get; set; }
    public DateTime StartTime { get; set; }
    public int DurationMinutes { get; set; }
    public string PaymentType { get; set; } = string.Empty;
    public string PaymentProvider { get; set; } = string.Empty;
    public bool IsPaid { get; set; }
    public string Description { get; set; } = string.Empty;
    public double PaidMoney { get; set; }
    public string PaymentDescription { get; set; } = string.Empty;   
    public int Stars { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
