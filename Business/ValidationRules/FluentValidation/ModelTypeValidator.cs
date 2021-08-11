using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelTypeValidator : AbstractValidator<ModelType>
    {
        public ModelTypeValidator()
        {
            RuleFor(type => type.TypeName)
                .Empty()
                .MinimumLength(3);
        }
    }
}
