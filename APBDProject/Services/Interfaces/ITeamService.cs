using APBDProject.API.DTOs;

namespace APBDProject.API.Services.Interfaces;

public interface ITeamService
{
    /// <summary>
    /// Returns a single team‑member (plus his/her tasks) or <c>null</c> when the id is unknown.
    /// </summary>
    Task<TeamMemberDto?> GetMemberAsync(int id, CancellationToken ct = default);
}