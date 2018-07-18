using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IFlightService
    {
        FlightDto Get(int id);
        List<FlightDto> Get();
        int Create(FlightDto flight);
        void Delete(int id);
        void Delete(FlightDto flight);
        void Update(FlightDto flight, int id);
        void Update(DateTime departureTime, DateTime destinationTime, int id);
        
    }
}
