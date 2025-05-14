using FluentValidation;
using MyRecipeBook.Communication.Request.Users;

namespace MyRecipeBook.Application.FluentValidation.User
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordRequestJson>
    {

        public ChangeUserPasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty();
            RuleFor(p => p.NewPassword.Length).GreaterThanOrEqualTo(6);
        }

    }
}
