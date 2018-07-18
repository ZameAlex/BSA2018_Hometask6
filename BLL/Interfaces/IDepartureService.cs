using BSA2018_Hometask4.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IDepartureService
    {
        DepartureDto Get(int id);
        List<DepartureDto> Get();
        int Create(DepartureDto flight);
        void Delete(int id);
        void Delete(DepartureDto flight);
        void Update(DepartureDto flight, int id);
        void Update(DateTime date,int id);

    }
}
