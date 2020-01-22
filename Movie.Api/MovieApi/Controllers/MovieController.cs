using System.Collections.Generic;
using System.Web.Http;
using Movie.Api.Models;
using Movie.Api.Providers;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/movies")]
    public class MovieController : ApiController
    {

        private readonly IMovieProvider movieProvider;

        public MovieController(IMovieProvider movieProvider)
        {
            this.movieProvider = movieProvider;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Models.Movie> GetMovies()
        {
            return movieProvider.GetMovies();
        }
    }
}
