using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface ICrewService
    {
        CrewDto Get(int id);
        List<CrewDto> Get();
        int Create(CrewDto flight);
        void Delete(int id);
        void Delete(CrewDto flight);
        void Update(CrewDto flight, int id);
        
    }
}
