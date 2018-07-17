using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using BSA2018_Hometask4.Shared.DTO;


namespace BSA2018_Hometask4.BLL.Validators
{
    public class TypeValidator:AbstractValidator<TypeDto>
    {
        public TypeValidator()
        {
            RuleFor(f => f.ID).Empty();
            RuleFor(t => t.Model).NotNull().NotEmpty();
            RuleFor(t => t.Places).NotNull().GreaterThan(0);
        }
    }
}
