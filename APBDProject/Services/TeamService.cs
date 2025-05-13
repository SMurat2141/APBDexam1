using APBDProject.API.DTOs;
using APBDProject.API.Repositories.Interfaces;
using AutoMapper;
using APBDProject.API.Services.Interfaces;   // <─ add / change

namespace APBDProject.API.Services;

public class TeamService : ITeamService
{
    private readonly ITeamMemberRepository _repo;
    private readonly IMapper _mapper;

    public TeamService(ITeamMemberRepository repo, IMapper mapper)
    {
        _repo   = repo;
        _mapper = mapper;
    }

    public async Task<TeamMemberDto?> GetMemberAsync(int id, CancellationToken ct = default)
    {
        var entity = await _repo.GetWithTasksAsync(id, ct);
        return entity is null ? null : _mapper.Map<TeamMemberDto>(entity);
    }
}