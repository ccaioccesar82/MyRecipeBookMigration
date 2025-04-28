using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("unactivate/user/{userId}")]
    [ApiController]
    public class UserUnactivateController : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Desactivate
            ([FromServices] IUnactivateUserUseCase userCase,
           Guid userId)
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
