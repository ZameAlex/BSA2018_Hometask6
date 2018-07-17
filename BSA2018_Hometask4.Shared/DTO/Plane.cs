using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.Shared.DTO
{
    public class PlaneDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public DateTime Created { get; set; }
        public TimeSpan Expires { get; set; }
    }
}
