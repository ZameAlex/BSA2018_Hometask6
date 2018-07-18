using System;
using System.Collections.Generic;
using System.Text;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Interfaces
{
    public interface ITypeService
    {
        TypeDto Get(int id);
        List<TypeDto> Get();
        int Create(TypeDto flight);
        void Delete(int id);
        void Delete(TypeDto flight);
        void Update(TypeDto flight, int id);

    }
}
