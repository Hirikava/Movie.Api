using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Api.Providers
{
    public interface IMovieProvider
    {
        IEnumerable<Models.Movie> GetMovies();
    }
}
