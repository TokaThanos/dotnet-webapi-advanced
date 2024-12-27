using Microsoft.AspNetCore.Mvc;

namespace WebApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Reading all projects.");
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok($"Reading a project #{id}");
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok("Creating a project.");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id)
    {
        return Ok($"Updating a project #{id}.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok($"Deleting a project #{id}.");
    }
}