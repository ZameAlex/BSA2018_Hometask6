using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IStewadressService
    {
        StewadressDto Get(int id);
        List<StewadressDto> Get();
        int Create(StewadressDto flight);
        void Delete(int id);
        void Delete(StewadressDto flight);
        void Update(StewadressDto flight, int id);
        
    }
}
