using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter02_1
{
    // Version 1
    class Program
    {
        static string url = @"Data\";
        static XDocument films = XDocument.Load(url + "MoviesDB.xml");
        static List<Movie> movies = new List<Movie>();
        static void Main(string[] args)
        {
            var movieCollection =
                (from f in films.Descendants("Movie")
                 select new Movie
                 {
                     ID = f.Element("Title").Value,
                     Title = f.Element("Title").Value,
                     OscarNominations = f.Element("OscarNominations").Value,
                     OscarWins = f.Element("OscarWins").Value
                 }).ToList();

            Console.WriteLine("Movie Titles");
            Console.WriteLine("------------");
            foreach (var movie in movieCollection.Take(10))
                Console.WriteLine(movie.Title);
            Console.ReadLine();
        }
    }
    public class Movie
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string OscarNominations { get; set; }
        public string OscarWins { get; set; }
    }

}
