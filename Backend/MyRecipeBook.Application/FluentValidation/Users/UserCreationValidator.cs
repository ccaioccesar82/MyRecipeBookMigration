using FluentValidation;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Exception;



namespace MyRecipeBook.Application.FluentValidation.Users
{
    public class UserCreationValidator : AbstractValidator<UserCreationRequest>
    {
        public UserCreationValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
            RuleFor(u => u.Email).NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);
            RuleFor(u => u.Email).EmailAddress().WithMessage(ResourceMessageException.INVALID_EMAIL);
            RuleFor(u => u.Password).NotEmpty().WithMessage(ResourceMessageException.PASSWORD_EMPTY);
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_LESS_CHARACTERS);

        }
    }
}