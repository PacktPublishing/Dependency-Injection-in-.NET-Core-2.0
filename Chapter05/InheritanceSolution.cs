using System;
using System.Collections.Generic;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
			User deliveryManager = new User()
            {
                RoleIds = new List<Role>
                {
                        new Manager(),
                        new TeamLead()
                }
            };

            Console.WriteLine(string.Format("User has Roles:\n\n\t- {0}", string.Join("\n\t- ", deliveryManager.RoleIds)));
			
			Console.ReadKey();
		}
	}
	
	public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class Admin : Role
    {
        public string CompanyDepartment { get; set; }

        public Admin()
        {
            RoleId = 1;
        }
    }

    public class Manager : Role
    {
        public List<TeamLead> TeamLeads { get; set; }

        public Manager()
        {
            RoleId = 2;
        }
    }

    public class TeamLead : Role
    {
        public List<string> Projects { get; set; }

        public TeamLead()
        {
            RoleId = 3;
        }
    }

    public class DeliveryHead : Role
    {
        public DeliveryHead()
        {
            RoleId = 4;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public List<Role> RoleIds { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }

        public int SaveUser(int userId)
        {
            // Database operation to save the user.
            return userId;
        }
    }
}