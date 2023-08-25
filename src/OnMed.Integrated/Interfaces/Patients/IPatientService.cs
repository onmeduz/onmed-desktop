namespace OnMed.Integrated.Interfaces.Patients;

public interface IPatientService
{
    public Task<long> GetCount(long id);
}
