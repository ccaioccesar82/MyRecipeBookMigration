using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.DashBoardUseCase;
using MyRecipeBook.Communication.Response.Recipes;

namespace MyRecipeBook.Api.Controllers.Dashboard
{
    
    [ApiController]
    [AutheticatedUser]
    public class DashBoardController : ControllerBase
    {

        [Route("dashboard")]
        [HttpGet]
        [ProducesResponseType(typeof(RecipeListResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DashBoard([FromServices] IDashBoardUseCase usecase)
        {
            var result = await usecase.Execute();
            if (result is null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
