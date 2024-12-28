using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ModelValidations;

public class Ticket_EnsureReportDatePresentAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;
        if (!ticket.ValidateReportDatePresence())
        {
            return new ValidationResult("Report date is required when the ticket has an owner");
        }
        return ValidationResult.Success;
    }
}