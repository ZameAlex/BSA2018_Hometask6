using BSA2018_Hometask4.Shared.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class FlightValidator:AbstractValidator<FlightDto>
    {
        public FlightValidator()
        {
            RuleFor(f => f.Number).NotNull().NotEmpty();
            RuleFor(f => f.DeparturePoint).NotNull().NotEmpty();
            RuleFor(f => f.Destination).NotNull().NotEmpty();
            RuleForEach(f => f.Tickets).NotNull().NotEmpty();
        }
    }
}
