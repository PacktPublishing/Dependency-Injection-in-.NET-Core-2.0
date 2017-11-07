class Program
{		
	static void Main(string[] args)
	{
		// Composing manually with DI Container is called as Poor Man's DI.
		// This might go ugly with when class heirarchy goes long.
		EmployeeService empService = new EmployeeService(new EmployeeRepository());

		Console.ReadKey();
	}
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository repository;

    // Default Constructor calls the parameterized one
    public EmployeeService() : this(new EmployeeRepository()) 
    {
    }

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        repository = employeeRepository;
    }
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ISomeClass class1;

    // Default constructor calls the parameterised one.
    public EmployeeRepository() : this(new Class1())
    {
    }

    public EmployeeRepository(ISomeClass someClass)
    {
        class1 = someClass;
    }
}