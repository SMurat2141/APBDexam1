using APBDProject.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APBDProject.API.Controllers;

[ApiController]
[Route("api/team-members")]
public class TeamMembersController : ControllerBase
{
    private readonly ITeamService _svc;
    public TeamMembersController(ITeamService svc) => _svc = svc;

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMember(int id, CancellationToken ct)
    {
        if (id <= 0)
            return BadRequest($"'{id}' is not a valid id.");

        var dto = await _svc.GetMemberAsync(id, ct);
        return dto is null
            ? NotFound($"Team member {id} not found.")
            : Ok(dto);
    }
}