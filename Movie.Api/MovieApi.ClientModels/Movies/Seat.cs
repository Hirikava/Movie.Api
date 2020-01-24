using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApi.ClientModels.Movies
{
    public class Seat
    { 
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
