using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string FilmName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
