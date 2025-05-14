using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;
using MyRecipeBook.Communication.Response.Users;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("user/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost]
        [ProducesResponseType(typeof(UserLoginResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromServices]IUserLoginUseCase useCase,
            [FromBody]UserRequestLogin request)
        {
            try
            {
                UserLoginResponseJson result = await useCase.Execute(request);

                return Ok(result);

            }
            catch (Exception e) { 
            
                return BadRequest(e.Message);
            }
        }
    }
}
