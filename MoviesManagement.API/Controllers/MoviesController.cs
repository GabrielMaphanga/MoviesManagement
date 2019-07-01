using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Core.Entities;
using MoviesManagement.Core.Interfaces;

namespace MoviesManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        /// <summary>
        /// Gets all Movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/movies")]
        public List<Movie> GetMovies()
        {
            return _moviesRepository.GetMovies();
        }
        /// <summary>
        /// Returns a specific movie using an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id}")]
        public Movie GetMovie(int id)
        {
            return _moviesRepository.GetMovie(id);
        }
        /// <summary>
        /// Saves a new movie
        /// </summary>
        /// <param name="movie"></param>

        [HttpPost]
        [Route("Add/movie")]
        public void AddMovie([FromBody]Movie movie)
        {
            _moviesRepository.AddMovie(movie);
        }
        /// <summary>
        /// Updates a specific movie        
        /// </summary>
        /// <param name="movie"></param>
        [HttpPut]
        [Route("Update/movie")]
        public void UpdateMovie([FromBody]Movie movie)
        {
            _moviesRepository.UpdateMovie(movie);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteMovie(int id)
        {
            _moviesRepository.DeleteMovie(id);
        }
    }
}