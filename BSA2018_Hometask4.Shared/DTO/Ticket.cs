using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.Shared.DTO
{
    public class TicketDto
    {
        public int ID { get; set; }
        public Guid Number { get; set; }
        public decimal Price { get; set; }
    }
}
