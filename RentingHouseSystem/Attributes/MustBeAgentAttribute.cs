using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RentingHouseSystem.Core.Contracts.Agent;
using RentingHouseSystem.Extensions;

namespace RentingHouseSystem.Attributes
{
    public class MustBeAgentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentService == null)
            {
                context.Result = new BadRequestObjectResult("Agent service is not available");
            }

            if (agentService != null && agentService.ExistByIdAsync(context.HttpContext.User.Id()).Result==false)
            {
              context.Result=new RedirectToActionResult("Become","Agent",null);
            }
        }
    }
}
