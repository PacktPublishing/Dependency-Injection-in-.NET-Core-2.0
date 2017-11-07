using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter02_1.Version2
{
    // In version 2, we use a dedicated class, XMLMovieReader 
    class Program2
    {
        static void Main(string[] args)
        {
            XMLMovieReader mr = new XMLMovieReader();
            var movieCollection = mr.ReadMovies();
            Console.WriteLine("Movie Titles");
            Console.WriteLine("------------");
            foreach (var movie in movieCollection.Take(10))
                Console.WriteLine(movie.Title);
            Console.ReadLine();
        }
    }
    public interface IMovieReader
    {
        List<Movie> ReadMovies();
    }
    public class XMLMovieReader : IMovieReader
    {
        static string url = @"Data\";
        static XDocument films = XDocument.Load(url + "MoviesDB.xml");
        static List<Movie> movies = new List<Movie>();
        public List<Movie> ReadMovies()
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
            return movieCollection;
        }
    }
}
