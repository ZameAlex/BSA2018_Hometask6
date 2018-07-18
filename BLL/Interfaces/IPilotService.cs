using BSA2018_Hometask4.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface ITicketService
    {
        TicketDto Get(int id);
        List<TicketDto> Get();
        int Create(TicketDto flight);
        void Delete(int id);
        void Delete(TicketDto flight);
        void Update(TicketDto flight, int id);

    }
}
