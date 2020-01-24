using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Api.Clients.Movies
{
    public interface IMovieClient
    {
        Task<IEnumerable<MovieApi.ClientModels.Movies.Movie>> GetMoviesByDate(DateTime dateTime);
        Task<IEnumerable<int>> GetClosedSeats(int movieId);

        Task<IEnumerable<int>> GetYourSeats(int movieId, string userId);
    }
}
