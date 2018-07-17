using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Departure:Entity
    {

        public Flight Flight { get; set; }
        [Column("DepartureDateTime")]
        public DateTime Date { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}
