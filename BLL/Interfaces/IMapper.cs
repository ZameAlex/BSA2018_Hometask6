using BSA2018_Hometask4.Shared.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IMapper
    {
        CrewDto MapCrew(Crew value);
        Crew MapCrew(CrewDto value);

        PilotDto MapPilot(Pilot value);
        Pilot MapPilot(PilotDto value);

        StewadressDto MapStewadress(Stewadress value);
        Stewadress MapStewadress(StewadressDto value);

        PlaneDto MapPlane(Plane value);
        Plane MapPlane(PlaneDto value);

        TypeDto MapType(PlaneType value);
        PlaneType MapType(TypeDto value);

        FlightDto MapFlight(Flight value);
        Flight MapFlight(FlightDto value);

        DepartureDto MapDeparture(Departure value);
        Departure MapDeparture(DepartureDto value);

        TicketDto MapTicket(Ticket value);
        Ticket MapTicket(TicketDto value);
    }
}
