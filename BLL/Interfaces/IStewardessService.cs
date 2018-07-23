using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IStewardessService
    {
        StewardessDto Get(int id);
        List<StewardessDto> Get();
        int Create(StewardessDto flight);
        void Delete(int id);
        void Delete(StewardessDto flight);
        void Update(StewardessDto flight, int id);
        
    }
}
