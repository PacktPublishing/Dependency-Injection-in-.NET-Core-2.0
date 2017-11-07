var employeeRepositoryTypeName = "Read from config"; //SqlEmployeeRepository
var connectionString = "Read from config";

var employeeRepositoryType = Type.GetType(employeeRepositoryTypeName, true);
var employeeRepository = Activator.CreateInstance(employeeRepositoryType, connectionString);