using Microsoft.AspNetCore.Mvc;
using WebApiProject.Filters;
using WebApiProject.Models;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Reading all tickets.");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok($"Reading a ticket #{id}");
    }

    [HttpPost]
    public IActionResult Post([FromBody] Ticket ticket)
    {
        return Ok(ticket);
    }

    [HttpPost]
    [Route("/api/v2/Tickets")]
    [Ticket_ValidateDateActionFilter]
    public IActionResult PostV2([FromBody] Ticket ticket)
    {
        return Ok(ticket);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Ticket ticket)
    {
        return Ok(ticket);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok($"Deleting a ticket #{id}.");
    }
}