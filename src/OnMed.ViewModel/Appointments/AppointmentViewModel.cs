namespace OnMed.ViewModel.Appointments;

public class AppointmentViewModel
{
    public long AppointmentId { get; set; }
    public long UserId { get; set; }
    public long DoctorId { get; set; }
    public long HospitalBranchId { get; set; }
    public string UserFullName { get; set; } = String.Empty;
    public string UserImagePath { get; set; } = String.Empty;
    public string UserPhoneNumber { get; set; } = String.Empty;
    public bool  UserIsMale{ get; set; }
    public string DoctorFullName { get; set; } = String.Empty;
    public bool doctorIsMale { get; set; }
    public string degree { get; set; } = String.Empty;
    public int Status { get; set; }
    public DateOnly RegisterDate { get; set; }
    public string StartTime { get; set; } = String.Empty;
    public int DurationMinutes { get; set; }
    public bool IsPaid { get; set; }
    public int PaidMoney { get; set; }
}
