using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class CrewValidator:AbstractValidator<CrewDto>
    {
        public CrewValidator()
        {
            RuleFor(c => c.Pilot).NotNull().GreaterThan(0);
            RuleForEach(c => c.Stewadress).NotNull().GreaterThan(0);
        }
    }
}
