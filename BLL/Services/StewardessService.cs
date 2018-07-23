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
    public class StewardessService : IStewardessService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<StewardessDto> validator;

        public StewardessService(IUnitOfWork uow, IMapper map, AbstractValidator<StewardessDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(StewardessDto Stewadress)
        {
            var validationResult = validator.Validate(Stewadress);
            if (validationResult.IsValid)
                return unit.Stewadresses.Create(mapper.MapStewadress(Stewadress));
            else
                throw new ValidationException(validationResult.Errors);

        }

        public void Delete(int id)
        {
            unit.Stewadresses.Delete(id);
        }

        public void Delete(StewardessDto Stewadress)
        {
            unit.Stewadresses.Delete(mapper.MapStewadress(Stewadress));
        }

        public StewardessDto Get(int id)
        {
            return mapper.MapStewadress(unit.Stewadresses.Get(id));
        }

        public List<StewardessDto> Get()
        {
            var result = new List<StewardessDto>();
            foreach (var item in unit.Stewadresses.Get())
            {
                result.Add(mapper.MapStewadress(item));
            }
            return result;
        }

        public void Update(StewardessDto Stewadress, int id)
        {
            var validationResult = validator.Validate(Stewadress);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Stewadress.ID = id;
                unit.Stewadresses.Update(mapper.MapStewadress(Stewadress), id);
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
