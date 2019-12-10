using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Api.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public int AgeLimitation { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }
}