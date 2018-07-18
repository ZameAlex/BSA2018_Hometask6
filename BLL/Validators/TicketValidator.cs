using BSA2018_Hometask4.Shared.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class TicketValidator:AbstractValidator<TicketDto>
    {
        public TicketValidator()
        {
            RuleFor(f => f.ID).Empty();
            RuleFor(t => t.Number).NotNull().NotEmpty();
            RuleFor(t => t.Price).NotNull().GreaterThan(0);
        }
    }
}
