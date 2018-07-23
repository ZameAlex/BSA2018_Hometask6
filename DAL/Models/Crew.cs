using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Crew:Entity
    {

        public Pilot Pilot { get; set; }
        public List<Stewardess> Stewadresses { get; set; }
    }
}
