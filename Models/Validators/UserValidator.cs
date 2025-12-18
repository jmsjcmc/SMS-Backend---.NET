using FluentValidation;

namespace SMS_backend.Models
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(X => X.FirstName)
                .NotEmpty().WithMessage("FIRST NAME REQUIRED");
            RuleFor(X => X.LastName)
                .NotEmpty().WithMessage("LAST NAME REQUIRED");
            RuleFor(X => X.Username)
                .NotEmpty().WithMessage("USERNAME REQUIRED");
            RuleFor(X => X.Password)
                .NotEmpty().WithMessage("PASSWORD REQUIRED");
        }
    }
    public class LogInRequestValidator : AbstractValidator<LogInRequest>
    {
        public LogInRequestValidator()
        {
            RuleFor(X => X.Username)
                .NotEmpty().WithMessage("USERNAME REQUIRED");
            RuleFor(X => X.Password)
                .NotEmpty().WithMessage("PASSWORD REQUIRED");
        }
    }
}
