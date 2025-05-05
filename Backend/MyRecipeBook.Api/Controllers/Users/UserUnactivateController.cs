using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Domain.Entities.User;

namespace MyRecipeBook.Api.Controllers.Users
{

    [AutheticatedUser]
    [Route("user/unactivate/{userId}")]
    [ApiController]
    public class UserUnactivateController : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Desactivate
            ([FromServices] IUnactivateUserUseCase userCase, Guid userId)
        {
            try
            {
                
                await userCase.Execute(userId);

                return Ok();

            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }
    }
}
