using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Ticket:Entity
    {

        public Flight Flight { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
