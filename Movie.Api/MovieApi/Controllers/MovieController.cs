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
                new Models.Movie(){Name = "Страх и ненависть в Самаре"},
                new Models.Movie(){Name = "Город под подошвой",AgeLimitation = 0,Genres = new List<MovieGenre>() {MovieGenre.Horror,MovieGenre.Adventure}}
            };
        }
    }
}
