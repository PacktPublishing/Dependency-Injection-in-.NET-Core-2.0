public class EmployeeService
{
	private readonly EmployeeRepository repository;

	public EmployeeService()
	{
			string connectionString = "Read String from config";
			this.repository = new SqlEmployeeRepository(connectionString);
	}
}