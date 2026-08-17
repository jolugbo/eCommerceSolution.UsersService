using eCommerce.Core.Dto;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator() { 
        RuleFor(temp=> temp.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$")
            .WithMessage("Password must be at least 8 characters long and contain at leastone uppercase letter, one lowercase letter, one number, and one special character.");
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("Person Name is required")
            .MaximumLength(2).WithMessage("Person Name must be at least 2 characters long")
            .MaximumLength(50).WithMessage("Person Name must be at more that 50 characters long");
        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Invalid Gender Input");
    }
}
