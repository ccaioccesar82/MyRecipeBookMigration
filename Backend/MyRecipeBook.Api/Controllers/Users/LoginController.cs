using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("user/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost]
        [ProducesResponseType(typeof(AccessTokenResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromServices]IUserLoginUseCase useCase,
            [FromBody]UserRequestLogin request)
        {

                AccessTokenResponseJson result = await useCase.Execute(request);

                return Ok(result);
           
        }
    }
}
