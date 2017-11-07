public class EmployeeService
{
    private readonly IEmployeeRepository repository;

    // Default Constructor.
    public EmployeeService()
    {
        repository = CreateDefaultRepository();
    }

    // Constructor Injection can happen here.
    public EmployeeService(IEmployeeRepository repository)
    {
        if (repository == null)
        {
            throw new ArgumentNullException("repository");
        }

        this.repository = repository;
    }

    // Method creating a default repository.
    private static EmployeeRepository CreateDefaultRepository()
    {
        string connectionString = "Read String from config";

        return new SqlEmployeeRepository(connectionString);
    }
}