using BSA2018_Hometask4.BLL.Interfaces;
using BSA2018_Hometask4.Shared.DTO;
using BSA2018_Hometask4.Shared.Exceptions;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Services
{
    public class TypeService : ITypeService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<TypeDto> validator;

        public TypeService(IUnitOfWork uow, IMapper map, AbstractValidator<TypeDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(TypeDto Type)
        {
            var validationResult = validator.Validate(Type);
            if (validationResult.IsValid)
                return unit.Types.Create(mapper.MapType(Type));
            else
                throw new ValidationException(validationResult.Errors);
        }

        public void Delete(int id)
        {
            unit.Types.Delete(id);
        }

        public void Delete(TypeDto Type)
        {
            unit.Types.Delete(mapper.MapType(Type));
        }

        public TypeDto Get(int id)
        {
            return mapper.MapType(unit.Types.Get(id));
        }

        public List<TypeDto> Get()
        {
            var result = new List<TypeDto>();
            foreach (var item in unit.Types.Get())
            {
                result.Add(mapper.MapType(item));
            }
            return result;
        }

        public void Update(TypeDto Type, int id)
        {
            var validationResult = validator.Validate(Type);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Type.ID = id;
                unit.Types.Update(mapper.MapType(Type), id);
            }
            catch (ArgumentNullException)
            {
                throw new NotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
