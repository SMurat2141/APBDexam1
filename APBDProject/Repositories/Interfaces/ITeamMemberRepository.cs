using APBDProject.API.Entities;

namespace APBDProject.API.Repositories.Interfaces;

public interface ITeamMemberRepository
{
    Task<TeamMember?> GetWithTasksAsync(int id, CancellationToken ct = default);
}