using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Core.ModelValidations;

public class Ticket_EnsureDueDateAfterReportDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var ticket = validationContext.ObjectInstance as Ticket;
        if (!ticket.ValidateDueDateAfterReportDate())
        {
            return new ValidationResult("Due date has to be later than the Report date");
        }
        return ValidationResult.Success;
    }
}