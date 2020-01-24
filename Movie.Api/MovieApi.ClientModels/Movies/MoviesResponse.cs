using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Movies
{
    public class MoviesResponse
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
