using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.UserUseCaseInterface;
using MyRecipeBook.Communication.Request.Users;
using MyRecipeBook.Communication.Response.Users;

namespace MyRecipeBook.Api.Controllers.Users
{
    [Route("create/user")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserCreationResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
           [FromServices] IUserCreateUserCase usecase,
           [FromBody] UserCreationRequest request)
        {
            try
            {
                var result = await usecase.Execute(request);

                return Created(string.Empty, result);
            }
            catch (Exception ex) 
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
