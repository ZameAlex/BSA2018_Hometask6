using BSA2018_Hometask4.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IPilotService
    {
        PilotDto Get(int id);
        List<PilotDto> Get();
        int Create(PilotDto flight);
        void Delete(int id);
        void Delete(PilotDto flight);
        void Update(PilotDto flight, int id);
        void Update(int experience, int id);

    }
}
