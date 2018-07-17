using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
    public class Stewadress:Entity
    {

        [StringLength(20)]
        [Column("FirstName")]
        public string Name { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
