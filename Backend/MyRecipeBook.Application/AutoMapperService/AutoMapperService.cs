/*using AutoMapper;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Domain.Entities.User;

namespace MyRecipeBook.Application.AutoMapperService
{
    public class AutoMapperValidator : Profile
    {

        public AutoMapperValidator()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<UserCreationRequest, Users>()
            .ForMember(user => user.Password, opt => opt.Ignore());

        }

    }
}
*/