using FluentValidation;

namespace SMS_backend.Models
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleValidator()
        {
            RuleFor(X => X.Name)
                .NotEmpty().WithMessage("NAME REQUIRED");
        }
    }
}
