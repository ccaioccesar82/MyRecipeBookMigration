using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Users;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("user/create")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserCreationResponseJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
           [FromServices] IUserCreateUserCase usecase,
           [FromBody] UserCreationRequest request)
        {
            try
            {
                UserCreationResponseJson result = await usecase.Execute(request);

                return Created(string.Empty, result);
            }
            catch (Exception ex) 
            {

                return BadRequest(ex.Message);
            }
        }
    }

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
            try
            {
                await usecase.Execute(request);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }



}
