


using MoviesManagement.Core.Entities;
using MoviesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MoviesManagement.Infrustructure.Data
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IConfiguration _config;

        public MoviesRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("MoviesDB"));

        public bool AddMovie(Movie movie)
        {


            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO dbo.Movie (Name, Category, Rating)"
                    + "VALUES(@Name, @Category, @Rating)";
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery, movie);
                if (rowAffectd > 0)
                {
                    return true;
                }
            }


           

           
            
            return false;
        }

        public bool DeleteMovie(int movieId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM Movie WHERE Id =" + movieId;
                dbConnection.Open();
                int rowAffectd = dbConnection.Execute(sQuery);
                if (rowAffectd > 0)
                {
                    return true;
                }


            }
            return false;
        }

        public Movie Find(int movieId)
        {
            Movie movie = new Movie();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM Movie WHERE Id =" + movieId;
                movie = dbConnection.QueryFirst<Movie>(query);
                dbConnection.Close();
            }
            return movie;
        }

        public Movie GetMovie(int movieId)
        {
            Movie movie = new Movie();

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM Movie WHERE Id =" + movieId;
                movie = dbConnection.QueryFirst<Movie>(query);
                dbConnection.Close();
            }
            return movie;
        }

        public List<Movie> GetMovies()
        {
            IEnumerable<Movie> movies = new List<Movie>();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "SELECT * FROM Movie";
                movies = dbConnection.Query<Movie>(query);
                dbConnection.Close();
            }
            return movies.AsList<Movie>();
        }

        public Movie UpdateMovie(Movie movie)
        {

            var updateMovie = new Movie();
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();              
               
                var query = "UPDATE Movie SET Name = @Name, Category = @Category, Rating = @Rating WHERE Id = @Id ";        

               
             
                updateMovie =dbConnection.ExecuteScalar<Movie>(query, movie);

            }
            return updateMovie;


        }
           
        
    }
}
