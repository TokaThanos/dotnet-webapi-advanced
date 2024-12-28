using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiProject.Filters;


/// <summary>
/// This attribute is not used in the code but kept for reference and learning
/// </summary>
public class Ticket_ValidateDateActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        bool isValid = true;
        var ticket = context.ActionArguments["ticket"] as Ticket;
        if (!string.IsNullOrWhiteSpace(ticket?.Owner) && !ticket.ReportDate.HasValue) 
        {
            isValid = false;
            context.ModelState.AddModelError("EnteredDate", "EnteredDate is required!");
        }
        if (ticket?.ReportDate > ticket?.DueDate)
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