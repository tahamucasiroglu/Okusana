using Microsoft.AspNetCore.Mvc.Filters;
using Okusana.Extensions;

namespace Okusana.API.Attributes
{
    public class LogConnectionAttribute : ActionFilterAttribute // istenilen yerde istekleri basar
    {
        private readonly ILogger<LogConnectionAttribute> logger;

        public LogConnectionAttribute(ILogger<LogConnectionAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string message = "";
            message += $"Date = {DateTime.Now}" + "\n";
            message += $" Host = {context.HttpContext.Request.Host.Host} \n";
            message += $" Port = {context.HttpContext.Request.Host.Port} \n";
            message += $" Response Code = {context.HttpContext.Response.StatusCode} \n";
            message += $" Controller = {context.Controller.GetType().Name} \n";
            message += $" ModelState.IsValid = {context.ModelState.IsValid} \n";
            message += $" RouteData Values = {context.RouteData.Values} \n";
            message += $" User Identity = {context.HttpContext.User.Identity} \n";
            message += $" User Identity = {context.HttpContext.User.Identities.Select(u => u.Name + " - " + u.Label + " - " + u.NameClaimType.ToString()).ToJson()} \n";
            message += $" Body = {context.RouteData.Values.ToJson()} \n";
            message += $" Body Json = \n";
            message += context.ActionArguments.ToJson();
            logger.LogInformation(message);
        }
    }
}
