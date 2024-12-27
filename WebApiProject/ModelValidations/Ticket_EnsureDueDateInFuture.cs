using System.ComponentModel.DataAnnotations;
using WebApiProject.Models;

namespace WebApiProject.ModelValidations;

public class Ticket_EnsureDueDateInFuture : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;
        if (ticket?.TicketId == null && ticket?.DueDate < DateTime.Now.Date)
        {
            return new ValidationResult("Due date needs to be in future");
        }
        return ValidationResult.Success;
    }
}