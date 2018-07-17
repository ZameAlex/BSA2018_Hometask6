using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.Shared.DTO
{
    public class FlightDto
    {
        public int ID { get; set; }
        public Guid Number { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public List<int> Tickets { get; set; }
    }
}
