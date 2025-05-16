using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.Interfaces.Recipe;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Api.Controllers.Recipes
{
    [Route("recipe/create")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeCreationUseCase _recipeCreate;

        public RecipeController(IRecipeCreationUseCase recipeCreate)
        {
            _recipeCreate = recipeCreate;
        }


        [HttpPost]
        public IActionResult Create([FromBody]RecipeRequestJson request)
        {
            var result = _recipeCreate.Execute(request);

            

            return Ok(result);
        }
    }
}
