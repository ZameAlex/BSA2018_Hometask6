using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class PilotValidator:AbstractValidator<PilotDto>
    {
        public PilotValidator()
        {
            RuleFor(f => f.ID).Empty();
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(p => p.LastName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(p => p.Birthday).NotNull().LessThan(new DateTime(1995, 1, 1));
            RuleFor(p => p.Experience).GreaterThanOrEqualTo(2);
        }
    }
}
