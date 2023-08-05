using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Models.ResponseModel;

namespace Okusana.API.Extensions
{
    static public class ModelStateExtension
    {
        static public BadRequestObjectResult ReturnError(this ModelStateDictionary ModelState, IHateoas? hateoas = null)
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
