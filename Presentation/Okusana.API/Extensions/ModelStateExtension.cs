using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Okusana.API.Models.HateoasModel;
using Okusana.API.Models.ResponseModel;

namespace Okusana.API.Extensions
{
    static public class ModelStateExtension
    {
        static public BadRequestObjectResult ReturnError(this ModelStateDictionary ModelState, Hateoas? hateoas = null)
        {
            string errorText = "";
            foreach (var key in ModelState.Keys)
            {
                errorText += ModelState[key]?.Errors.FirstOrDefault()?.ErrorMessage + "\n";
            }
            return new BadRequestObjectResult(new Response(errorText, hateoas));
        }
    }
}
