using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Chapter02_1.Version3
{
    // In version 3, we use two distinct formats (XMl and JSON).
    // The ReaderFactory class decides which instance of IMovieReader we use
    class Program3
    {
        static IMovieReader _IMovieReader;
        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 15);
            Console.WriteLine("Please, select the file type to read (1) XML, (2) JSON: ");
            var ans = Console.ReadLine();
            var fileType = (ans == "1") ? "XML" : "JSON";
            _IMovieReader = new ReaderFactory(fileType)._IMovieReader;
            var typeSelected = _IMovieReader.GetType().Name;
            var movieCollection = _IMovieReader.ReadMovies();
            Console.WriteLine($"Movie Titles ({typeSelected})");
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
    public class JSONMovieReader : IMovieReader
    {
        static string file = @"Data\MoviesDB.json";
        static List<Movie> movies = new List<Movie>();
        public List<Movie> ReadMovies()
        {
            var moviesText = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<List<Movie>>(moviesText);
        }
    }
    public class ReaderFactory
    {
        public IMovieReader _IMovieReader { get; }
        public ReaderFactory(string fileType)
        {
            switch (fileType)
            {
                case "XML":
                    _IMovieReader = new XMLMovieReader();
                    break;
                case "JSON":
                    _IMovieReader = new JSONMovieReader();
                    break;
                // for any non-registered value _IMovieReader is null
                default: break;
            }
        }
    }
}
