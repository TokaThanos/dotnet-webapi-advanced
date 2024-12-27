using System.ComponentModel.DataAnnotations;
using WebApiProject.ModelValidations;

namespace WebApiProject.Models;

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

    public DateTime? EnteredDate { get; set; }
    
    [Ticket_EnsureDueDateForTicketOwner]
    [Ticket_EnsureDueDateInFuture]
    public DateTime? DueDate { get; set; }
}