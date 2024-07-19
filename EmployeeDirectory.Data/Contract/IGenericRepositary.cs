namespace EmployeeDirectory.Data.Contract
{
    public interface IGenericRepositary<T> where T : class
    {
        List<T> GetData();
        T? GetDataById(int id);
        string? GetNameById(int? id);
    }
}