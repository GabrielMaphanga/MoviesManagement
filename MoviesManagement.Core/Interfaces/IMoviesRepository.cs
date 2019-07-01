using MoviesManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Interfaces
{
    public interface IMoviesRepository
    {
        Movie GetMovie(int movieId);
        List<Movie> GetMovies();
        bool DeleteMovie(int movieId);
        Movie UpdateMovie(Movie movie);
        bool AddMovie(Movie movie);

        Movie Find(int movieId);



    }
}
