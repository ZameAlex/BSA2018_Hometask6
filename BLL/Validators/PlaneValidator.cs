using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;


namespace BSA2018_Hometask4.BLL.Validators
{
    public class PlaneValidator:AbstractValidator<PlaneDto>
    {
        public PlaneValidator()
        {
            RuleFor(f => f.ID).Empty();
            RuleFor(p => p.Type).NotNull().GreaterThan(0);
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(p => p.Created).NotNull().NotEmpty();
            RuleFor(p => p.Expires).NotNull().GreaterThan(new TimeSpan(30, 0, 0, 0));
        }
    }
}
