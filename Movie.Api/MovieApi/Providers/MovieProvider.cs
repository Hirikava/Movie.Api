using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movie.Api.Models;

namespace Movie.Api.Providers
{
    public class MovieProvider : IMovieProvider
    {
        public IEnumerable<Models.Movie> GetMovies()
        {
            return new List<Models.Movie>()
            {
                new Models.Movie(){Name = "Страх и ненависть в Самаре"},
                new Models.Movie(){Name = "Город под подошвой",AgeLimitation = 0,Genres = new List<MovieGenre>() {MovieGenre.Horror,MovieGenre.Adventure}}
            };
        }
    }
}