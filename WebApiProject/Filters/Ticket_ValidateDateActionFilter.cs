using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiProject.Models;

namespace WebApiProject.Filters;

public class Ticket_ValidateDateActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        bool isValid = true;
        var ticket = context.ActionArguments["ticket"] as Ticket;
        if (!string.IsNullOrWhiteSpace(ticket?.Owner) && !ticket.EnteredDate.HasValue) 
        {
            isValid = false;
            context.ModelState.AddModelError("EnteredDate", "EnteredDate is required!");
        }
        if (ticket?.EnteredDate > ticket?.DueDate)
        {
            isValid = false;
            context.ModelState.AddModelError("DueDate", "DueDate has to be later than the EnteredDate");
        }
        if (!isValid)
        {
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}