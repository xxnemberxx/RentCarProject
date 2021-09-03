using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.LicensePlate).NotEmpty();
            RuleFor(v => v.OfferPercent).NotEqual(0);
            RuleFor(v => v.Location)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(500);
        }
    }
}
