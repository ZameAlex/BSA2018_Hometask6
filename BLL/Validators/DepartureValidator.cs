using BSA2018_Hometask4.Shared.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class DepartureValidator : AbstractValidator<DepartureDto>
    {
        public DepartureValidator()
        {
            RuleFor(d => d.Number).NotNull().NotEmpty();
            RuleFor(d => d.Date).NotNull();
            RuleFor(d => d.CrewId).NotNull().NotEqual(0);
            RuleFor(d => d.PlaneId).NotNull().NotEqual(0);
        }
    }
}