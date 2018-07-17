using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Flight : Entity
    {
    
        public Guid Number { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public string DestinationPoint { get; set; }
        public DateTime DestinationTime { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
