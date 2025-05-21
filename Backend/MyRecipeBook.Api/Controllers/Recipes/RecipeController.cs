using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Application.UseCases.Interfaces.Recipe;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Api.Controllers.Recipes
{
    [Route("recipe/create")]
    [ApiController]
    [AutheticatedUser]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeCreationUseCase _recipeCreate;

        public RecipeController(IRecipeCreationUseCase recipeCreate)
        {
            _recipeCreate = recipeCreate;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RecipeRequestJson request)
        {
            try
            {
                var result = await _recipeCreate.Execute(request);



                return Ok(result);

            }catch(Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
