using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Project
{
    public int ProjectId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public List<Ticket> Tickets { get; set; }
}