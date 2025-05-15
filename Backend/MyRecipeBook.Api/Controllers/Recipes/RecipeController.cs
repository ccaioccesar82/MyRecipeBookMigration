using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Attributes;
using MyRecipeBook.Communication.Request.Recipes;

namespace MyRecipeBook.Api.Controllers.Recipes
{
    [Route("recipe/create")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpPost]
        [AutheticatedUser]
        public IActionResult Create([FromBody]RecipeRequestJson request)
        {

            return Ok();
        }
    }
}
