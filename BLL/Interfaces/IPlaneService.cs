using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface IPlaneService
    {
        PlaneDto Get(int id);
        List<PlaneDto> Get();
        int Create(PlaneDto flight);
        void Delete(int id);
        void Delete(PlaneDto flight);
        void Update(PlaneDto flight, int id);
        void Update(TimeSpan expires, int id);

    }
}
