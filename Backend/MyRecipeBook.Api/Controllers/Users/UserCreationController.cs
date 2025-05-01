using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Token;
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
}
