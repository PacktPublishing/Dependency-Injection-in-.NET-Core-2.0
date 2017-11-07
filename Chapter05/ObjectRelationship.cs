using System;

namespace DependencyExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Packt packt = new Packt
            {
                Name = "Packt Publications",
                OfficialFacebookLink = "https://www.facebook.com/PacktPub/",
                TotalBooksPublished = 5000
            };

            packt.PrintPacktInfo();

            Console.ReadKey();
        }
    }
	
	class Organisation
    {
        public Organisation() { }
        public string Name { get; set; }
        public string OfficialFacebookLink { get; set; }
    }

    class Packt : Organisation
    {
        public Packt() { }
        public int TotalBooksPublished { get; set; }

        public void PrintPacktInfo()
        {
            Console.WriteLine($"This is {Name}!\n" +
                $"Our official facebook page link is {OfficialFacebookLink}.\n" +
                $"We have published {TotalBooksPublished} books.\n");

            Account account = new Account();
            account.PrintAcountInfo(1, "Packt Account");
        }
    }

    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public void PrintAcountInfo(int accId, string accName)    
        {
            Console.WriteLine("Account Id: " + accId + " and Account Name: " + accName);
        }
    }
}