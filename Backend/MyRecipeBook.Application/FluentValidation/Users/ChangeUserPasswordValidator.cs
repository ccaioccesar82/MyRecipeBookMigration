using FluentValidation;
using MyRecipeBook.Communication.Request.Users;

namespace MyRecipeBook.Application.FluentValidation.Users
{
    public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordRequestJson>
    {

        public ChangeUserPasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Senha não pode ser vazia");
            RuleFor(p => p.NewPassword.Length).GreaterThanOrEqualTo(6).WithMessage("Senha não pode ser menor do que 6 caracteres");
        }

    }
}
