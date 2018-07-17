using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.Shared.DTO
{
    public class DepartureDto
    {
        public int ID { get; set; }
        public Guid Number { get; set; }
        public DateTime Date { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}
