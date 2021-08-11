using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.EmailAdress)
                .EmailAddress()
                .MaximumLength(254);
            RuleFor(c => c.Gender)
                .Empty();
            RuleFor(c => c.PhoneNumber)
                .Empty()
                .MinimumLength(4)
                .MaximumLength(12);
            RuleFor(c => c.BirthDate)
                .Empty();
            RuleFor(c => c.FirstName)
                .Empty()
                .MinimumLength(3);
            RuleFor(c => c.LastName)
                .Empty()
                .MinimumLength(3);
            RuleFor(c => c.NationalityId)
                .Empty()
                .MinimumLength(11);
        }
    }
}
