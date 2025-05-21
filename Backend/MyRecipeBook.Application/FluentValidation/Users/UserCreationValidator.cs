using FluentValidation;
using MyRecipeBook.Communication.Request.Users;


namespace MyRecipeBook.Application.FluentValidation.Users
{
    public class UserCreationValidator : AbstractValidator<UserCreationRequest>
    {
        public UserCreationValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Nome não pode ser vazio");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email não pode ser vazio");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email inválido");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Senha não pode ser vazia");
            RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Senha não pode ser menor do que 6 caracteres");

        }
    }
}