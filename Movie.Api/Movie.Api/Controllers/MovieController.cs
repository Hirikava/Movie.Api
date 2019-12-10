using System.Collections.Generic;
using System.Web.Http;
using Movie.Api.Models;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/movies")]
    public class MovieController : ApiController
    {

        [HttpGet]
        [Route("")]
        public List<Models.Movie> GetMovies()
        {
            return new List<Models.Movie>()
            {
                new Models.Movie(){Name = "AAAA",AgeLimitation = 0,Genres = new List<MovieGenre>() {MovieGenre.Horror,MovieGenre.Adventure}}
            };
        }
    }
}
