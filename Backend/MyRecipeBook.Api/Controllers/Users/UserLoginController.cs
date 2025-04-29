using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("user/login")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> Login([FromServices]IUserLoginUseCase useCase,
            [FromBody]UserRequestLogin request)
        {
            try
            {
                await useCase.Execute(request);

                return Ok();

            }
            catch (Exception e) { 
            
                return BadRequest(e.Message);
            }
        }
    }
}
