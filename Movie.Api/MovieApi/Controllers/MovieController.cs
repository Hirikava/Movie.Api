using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Movie.Api.Clients.Movies;
using Movie.Api.Providers.Authorization;
using MovieApi.ClientModels.Movies;

namespace Movie.Api.Controllers
{
    [RoutePrefix("v1/movies")]
    public class MovieController : ApiController
    {

        private readonly IMovieClient movieClient;
        private readonly IAuthorizationProvider authorizationProvider;

        public MovieController(IMovieClient movieClient, IAuthorizationProvider authorizationProvider)
        {
            this.movieClient = movieClient;
            this.authorizationProvider = authorizationProvider;
        }

        [HttpGet]
        [Route("")]
        public async Task<MoviesResponse> GetMovies([FromUri] DateTime date)
        {
            return new MoviesResponse()
            {
                Movies = await movieClient.GetMoviesByDate(date).ConfigureAwait(false),
            };
        }

        [HttpGet]
        [Route("{movieId}/seats")]
        public async Task<SeatResponse> GetSeats(int movieId)
        {
            var seats = new List<Seat>();
            for(int i = 1; i < 50; i++)
                seats.Add(new Seat()
                {
                    SeatNumber = i,
                    SeatStatus = SeatStatus.Open,
                });

            foreach (var seatNumber in (await movieClient.GetClosedSeats(movieId)))
                seats[seatNumber].SeatStatus = SeatStatus.Closed;

            foreach (var seatNumber in (await movieClient.GetYourSeats(movieId,await authorizationProvider.GetUserId())))
                seats[seatNumber].SeatStatus = SeatStatus.Closed;

            return new SeatResponse()
            {
                Seats = seats,
            };
        }
    }
}