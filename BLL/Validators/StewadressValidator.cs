using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;

namespace BSA2018_Hometask4.BLL.Validators
{
    public class StewadressValidator:AbstractValidator<StewadressDto>
    {
        public StewadressValidator()
        {
            RuleFor(f => f.ID).Empty(); 
            RuleFor(s => s.FirstName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(s => s.LastName).NotNull().NotEmpty().MaximumLength(30);
            RuleFor(s => s.Birthday).NotNull().LessThan(new DateTime(2000, 1, 1));
        }
    }
}
