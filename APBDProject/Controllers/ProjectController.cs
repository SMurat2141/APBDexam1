using APBDProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBDProject.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _svc;
    public ProjectsController(IProjectService svc) => _svc = svc;

    /// <summary>Deletes a project plus all its tasks in one DB transaction.</summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProject(int id, CancellationToken ct)
    {
        if (id <= 0)
            return BadRequest($"'{id}' is not a valid id.");

        bool removed;
        try
        {
            removed = await _svc.DeleteProjectAsync(id, ct);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                $"Could not delete project {id}. {ex.Message}");
        }

        return removed
            ? NoContent()
            : NotFound($"Project {id} not found.");
    }
}