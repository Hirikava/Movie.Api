using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Movie.Api.Providers.DataBase;

namespace Movie.Api.Clients.Movies
{
    public class MovieClient : IMovieClient
    {

        private readonly IDataBaseConnectionProvider dataBaseConnectionProvider;

        public MovieClient(IDataBaseConnectionProvider dataBaseConnectionProvider)
        {
            this.dataBaseConnectionProvider = dataBaseConnectionProvider;
        }

        public async Task<IEnumerable<MovieApi.ClientModels.Movies.Movie>> GetMoviesByDate(DateTime dateTime)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Movies WHERE MovieDate='{dateTime.Date}'", connection);
                var movies = new List<MovieApi.ClientModels.Movies.Movie>();
                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                while (reader.Read())
                {
                    movies.Add(new MovieApi.ClientModels.Movies.Movie()
                    {
                        Id = reader.GetInt32(0),
                        FilmName = reader.GetString(1),
                        Date = reader.GetDateTime(2),
                        Time = reader.GetTimeSpan(3),
                    });
                }
                reader.Close();
                return movies;
            }
        }

        public async Task<IEnumerable<int>> GetClosedSeats(int movieId)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Registrations WHERE MovieId={movieId}", connection);
                var seats = new List<int>();
                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                while (reader.Read())
                {
                    seats.Add(reader.GetInt32(2));
                }
                reader.Close();
                return seats;
            }
        }

        public async Task<IEnumerable<int>> GetYourSeats(int movieId, string userId)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM Registrations WHERE MovieId={movieId} AND UserId='{userId}'", connection);
                var seats = new List<int>();
                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                while (reader.Read())
                {
                    seats.Add(reader.GetInt32(2));
                }
                reader.Close();
                return seats;
            }
        }

        public async Task<bool> PatchSeat(int movieId, int seatId, string userId)
        {
            using (var connection = dataBaseConnectionProvider.GetConnection())
            {
                connection.Open();
                var checkCommand = new SqlCommand($"SELECT * FROM Registrations WHERE MovieId ={ movieId } AND SeatNumber = {seatId}",connection);
                var checkResult = await checkCommand.ExecuteReaderAsync();
                if (checkResult.HasRows)
                    return false;
                checkResult.Close();
                var insertCommand = new SqlCommand($"INSERT INTO Registrations VALUES ('{userId}',{movieId},{seatId})", connection);
                var result = (await insertCommand.ExecuteNonQueryAsync().ConfigureAwait(false));
                return true;
            }
        }
    }
}