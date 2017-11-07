using System;
using System.Collections.Generic;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
			Admin admin = new Admin()
			{
                Id = 12
			};
			admin.SaveUser(admin.Id);

			Manager manager = new Manager
			{
					Id = 13
			};
			manager.SaveUser(manager.Id);

			Console.WriteLine("Admin (Role Id: {0}) with UserId {1} is saved", admin.RoleId, admin.Id);
			Console.WriteLine("Manager (Role Id: {0}) with UserId {1} is saved", manager.RoleId, manager.Id);
			
			Console.ReadKey();
		}
	}
	
	public abstract class User
	{
		public int Id { get; set; }
		public int RoleId { get; set; }
		public string Name { get; set; }
		public string EmailId { get; set; }
		public string MobileNumber { get; set; }

		public int SaveUser(int userId)
		{
			// Database operation to save the user.
			return userId;
		}
	}

	public class Admin : User
	{
		public string CompanyDepartment { get; set; }

		public Admin()
		{
				RoleId = 1;
		}
	}

	public class Manager : User
	{
		public List<TeamLead> TeamLeads { get; set; }

		public Manager()
		{
				RoleId = 2;
		}
	}

	public class TeamLead : User
	{
		public List<string> Projects { get; set; }

		public TeamLead()
		{
				RoleId = 3;
		}
	}
}