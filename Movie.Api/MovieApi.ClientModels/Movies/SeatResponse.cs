using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Movies
{
    public class SeatResponse
    {
        public IEnumerable<Seat> Seats { get; set; }
        public int MovieId { get; set; }
    }
}
