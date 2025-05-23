using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.RecipeUseCase;
using MyRecipeBook.Communication.Request.Recipes;
using MyRecipeBook.Communication.Response.Recipes;
using MyRecipeBook.Exception.ExceptionBase;

namespace MyRecipeBook.Api.Controllers.Recipes
{
    
    [ApiController]
    [AutheticatedUser]
    public class RecipeController : ControllerBase
    {
        [Route("recipe/create")]
        [HttpPost]
        [ProducesResponseType(typeof(RecipeCreationResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]RecipeCreationRequestJson request,
            [FromServices]IRecipeCreationUseCase recipeCreate)
        {
                var result = await recipeCreate.Execute(request);

                return Created(string.Empty,result);

   
        }

        [Route("recipe/filter")]
        [HttpPost]
        [ProducesResponseType(typeof(RecipeFilteredResponseJson),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Index([FromBody]RecipeFilterRequestJson request, [FromServices] IFilterRecipesUseCase usecase)
        {

                var result = await usecase.Execute(request);

                return Ok(result);
            

        }

    }
}
