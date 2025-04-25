using System.Globalization;

namespace MyRecipeBook.Api.Middlewares
{
    public class CultureLanguage
    {
        private readonly RequestDelegate _next;


        public CultureLanguage(RequestDelegate next)
        {

            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {

            var allLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var languageResult = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en");

            if (string.IsNullOrEmpty(languageResult) == false && allLanguages.Any(c => c.Name.Equals(languageResult)))
            {

                cultureInfo = new CultureInfo(languageResult);

            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;



            await _next(context);

        }
    }
}