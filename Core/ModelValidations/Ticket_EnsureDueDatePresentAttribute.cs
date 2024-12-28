using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ModelValidations;

public class Ticket_EnsureDueDatePresentAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;
        if (!ticket.ValidateDueDatePresence())
        {
            return new ValidationResult("Due date is required when the ticket has an owner");
        }
        return ValidationResult.Success;
    }
}