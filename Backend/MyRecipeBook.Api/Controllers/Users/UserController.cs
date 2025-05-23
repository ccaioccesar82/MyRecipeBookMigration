using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Users;

namespace MyRecipeBook.Api.Controllers.Users
{
    [ApiController]
    public class Users : ControllerBase
    {


        [Route("user/create")]
        [HttpPost]
        [ProducesResponseType(typeof(UserCreationResponseJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
           [FromServices] IUserCreateUserCase usecase,
           [FromBody] UserCreationRequest request)
        {
   
                UserCreationResponseJson result = await usecase.Execute(request);

                return Created(string.Empty, result);
            }
 
        }
    }

    [AutheticatedUser]
    [Route("user/unactivate")]
    [ApiController]
    public class UserUnactivateController : ControllerBase
    {
        [HttpDelete]
        public async Task<IActionResult> Desactivate
            ([FromServices] IUnactivateUserUseCase userCase)
        {

                await userCase.Execute();

                return Ok();

        }
    }

    [AutheticatedUser]
    [Route("user/change-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiController]
    public class ChangeUserPasswordController : ControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> ChangePassword
            (IChangeUserPasswordUseCase usecase, [FromBody]ChangeUserPasswordRequestJson request)
        {

                await usecase.Execute(request);

                return Ok();

        }

}
