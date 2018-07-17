using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Plane:Entity
    {

        public string Name { get; set; }
        public PlaneType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
    }
}
