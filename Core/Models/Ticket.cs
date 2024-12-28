using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Core.ModelValidations;

namespace Core.Models;

public class Ticket
{
    public int? TicketId { get; set; }

    [Required]
    public int? ProjectId { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    public string? Description { get; set; }

    [StringLength(50)]
    public string? Owner { get; set; }

    [Ticket_EnsureReportDatePresent]
    public DateTime? ReportDate { get; set; }

    [Ticket_EnsureDueDatePresent]
    [Ticket_EnsureFutureDueDate]
    [Ticket_EnsureDueDateAfterReportDate]
    public DateTime? DueDate { get; set; }

    public Project? Project { get; set; }

    /// <summary>
    /// When owner is assigned, the due date has to be present
    /// </summary>
    public bool ValidateDueDatePresence()
    {
        if (string.IsNullOrWhiteSpace(Owner)) return true;
        return DueDate.HasValue;
    }

    /// <summary>
    /// When owner is assigned, the due date has to be present
    /// </summary>
    public bool ValidateReportDatePresence()
    {
        if (string.IsNullOrWhiteSpace(Owner)) return true;
        return ReportDate.HasValue;
    }

    /// <summary>
    /// When creating a ticket, if due date is present, it has to be in the future
    /// </summary>
    /// <returns></returns>
    public bool ValidateFutureDueDate()
    {
        if (TicketId.HasValue || !DueDate.HasValue) return true;
        return (DueDate.Value.Date >= DateTime.Now.Date);
    }

    /// <summary>
    /// When due date and report date is present, due date needs to be greater or equal to report date
    /// </summary>
    public bool ValidateDueDateAfterReportDate()
    {
        if (!DueDate.HasValue || !ReportDate.HasValue) return true;
        return DueDate.Value.Date >= ReportDate.Value.Date;
    }
}