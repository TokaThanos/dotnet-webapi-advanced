using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ModelValidations;

public class Ticket_EnsureFutureDueDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;
        if (!ticket.ValidateFutureDueDate())
        {
            return new ValidationResult("Due date needs to be in future");
        }
        return ValidationResult.Success;
    }
}