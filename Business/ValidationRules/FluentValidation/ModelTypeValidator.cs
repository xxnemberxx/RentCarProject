using Entities.Concrete;
using FluentValidation;

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
