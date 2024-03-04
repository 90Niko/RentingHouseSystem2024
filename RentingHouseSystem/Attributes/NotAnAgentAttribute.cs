using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Extensions;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;
using System.Security.Claims;



namespace RentingHouseSystem.Attributes
{
    public class NotAnAgentAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentService == null)
            {
                context.Result = new BadRequestObjectResult("Agent service is not available");
            }

            if (agentService != null && agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new BadRequestObjectResult("You are already an agent");
            }
        }
    }
}
