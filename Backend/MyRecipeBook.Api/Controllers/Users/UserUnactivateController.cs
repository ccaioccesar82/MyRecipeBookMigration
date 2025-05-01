using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("user/unactivate/{userId}")]
    [ApiController]
    [Authorize]
    public class UserUnactivateController : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Desactivate
            ([FromServices] IUnactivateUserUseCase userCase,
           Guid userIdToDelete)
        {
            try
            {
                
                await userCase.Execute(userIdToDelete);

                return Ok();

            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }
    }
}
