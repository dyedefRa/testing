using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.MvcWebUI.Models
{
    public static class MovieRepository
    {
        private static List<Movie> movies = null;

        static MovieRepository()
        {
            movies = new List<Movie>()
            {
                new Movie(){Id=1, Name="Wanted" },
                new Movie(){Id=2 , Name="Total Recall"},
                new Movie(){Id=3 , Name="Rex 1"},
                new Movie(){Id=4 , Name="Roc 3"},
                new Movie(){Id=5, Name="Rex 2" },
                new Movie(){Id=6 , Name="Roc 1"},
                new Movie(){Id=7 , Name="Roc 2"},
                new Movie(){Id=8 , Name="Persius"}
            };
        }
        public static List<Movie> ListMovies
        {
            get { return movies; }
        }
        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
        public static Movie GetById(int id)
        {
            return movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
