using Microsoft.EntityFrameworkCore;
using APBDProject.API.Data;
using APBDProject.API.Entities;
using APBDProject.API.Repositories.Interfaces;

namespace APBDProject.API.Repositories.Ef;

public class TeamMemberRepository : ITeamMemberRepository
{
    private readonly AppDbContext _ctx;
    public TeamMemberRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<TeamMember?> GetWithTasksAsync(int id, CancellationToken ct = default) =>
        await _ctx.TeamMembers
            .Include(tm => tm.TasksAssigned.OrderByDescending(t => t.Deadline))
            .Include(tm => tm.TasksCreated .OrderByDescending(t => t.Deadline))
            .FirstOrDefaultAsync(tm => tm.IdTeamMember == id, ct);
}