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
        public async Task<IActionResult> Index([FromBody]RecipeFilterRequestJson request, [FromServices] IFindRecipes usecase)
        {

                var result = await usecase.FilterRecipe(request);

                return Ok(result);
            

        }


        [Route("recipe/delete/{recipeId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid recipeId, [FromServices] IDeleteRecipeUseCase usecase)
        {
            await usecase.Execute(recipeId);

            return Ok();
        }



        [Route("recipe/{recipeId}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchRecipe(Guid recipeId, [FromServices] IFindRecipes usecase)
        {

            var result = await usecase.FindRecipe(recipeId);

            return Ok(result);
        }


        [Route("recipe/update/{recipeId}")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Guid recipeId, [FromBody] RecipeUpdateRequestJson request )
        {

  
            return Ok();
        }

    }

}

