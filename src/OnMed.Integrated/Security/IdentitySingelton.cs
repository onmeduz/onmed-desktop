namespace OnMed.Integrated.Security;

public class IdentitySingelton
{
    private static IdentitySingelton _identitySingelton;

    public string Token { get; set; }
    public long AdminId { get; set; }
    public long HospitalBranchId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

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
