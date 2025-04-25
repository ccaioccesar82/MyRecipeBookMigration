using FluentValidation;
using MyRecipeBook.Communication.Request.Users;


namespace MyRecipeBook.Application.FluentValidation.User
{
    internal class UserCreationValidator : AbstractValidator<UserCreationRequest>
    {
        public UserCreationValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6);

        }
    }
}