using FluentValidation;

namespace Nutcache.Domain.EntitiesValidators
{
    public class EmployeeValidator : BaseValidator<Entities.Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(512)
                .WithMessage("Invalid Email");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(256)
                .WithMessage("Invalid Name");

            RuleFor(x => x.BirthDate).NotNull().WithMessage("Invalid Birth Date");
            RuleFor(x => x.StartDate).NotNull().WithMessage("Invalid Start Date");
        }
    }
}
