namespace OnMed.Integrated.Security;

public class IdentitySingelton
{
    private static IdentitySingelton _identitySingelton;

    public string Token { get; set; }
    public long AdminId { get; set; }
    public long HospitalBranchId { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string MiddleName { get; set; }
    public string ImagePath { get; set; }
    public string HospitalName { get; set; }

    private IdentitySingelton()
    {
    }

    public static IdentitySingelton GetInstance()
    {
        if (_identitySingelton is null)
            _identitySingelton = new IdentitySingelton();
        return _identitySingelton;

    }
}
