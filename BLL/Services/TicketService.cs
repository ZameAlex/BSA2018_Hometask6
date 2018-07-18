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
    public class TicketService : ITicketService
    {
        readonly IUnitOfWork unit;
        readonly IMapper mapper;
        readonly AbstractValidator<TicketDto> validator;

        public TicketService(IUnitOfWork uow, IMapper map, AbstractValidator<TicketDto> rules)
        {
            unit = uow;
            mapper = map;
            validator = rules;
        }
        public int Create(TicketDto Ticket)
        {
            var validationResult = validator.Validate(Ticket);
            if (validationResult.IsValid)
                return unit.Tickets.Create(mapper.MapTicket(Ticket));
            else
                throw new ValidationException(validationResult.Errors);
            
        }

        public void Delete(int id)
        {
            unit.Tickets.Delete(id);
        }

        public void Delete(TicketDto Ticket)
        {
            unit.Tickets.Delete(mapper.MapTicket(Ticket));
        }

        public TicketDto Get(int id)
        {
            return mapper.MapTicket(unit.Tickets.Get(id));
        }

        public List<TicketDto> Get()
        {
            var result = new List<TicketDto>();
            foreach (var item in unit.Tickets.Get())
            {
                result.Add(mapper.MapTicket(item));
            }
            return result;
        }

        public void Update(TicketDto Ticket, int id)
        {
            var validationResult = validator.Validate(Ticket);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            try
            {
                Ticket.ID = id;
                unit.Tickets.Update(mapper.MapTicket(Ticket), id);
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
