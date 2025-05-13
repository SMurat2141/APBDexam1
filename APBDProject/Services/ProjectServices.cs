using APBDProject.API.Data;
using APBDProject.API.Repositories.Interfaces;
using APBDProject.API.Services.Interfaces;   // <─ add / change

namespace APBDProject.API.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repo;
    private readonly AppDbContext       _ctx;

    public ProjectService(IProjectRepository repo, AppDbContext ctx)
    {
        _repo = repo;
        _ctx  = ctx;
    }

    public async Task<bool> DeleteProjectAsync(int id, CancellationToken ct = default)
    {
        var project = await _repo.GetAsync(id, ct);
        if (project is null) return false;

        using var tr = await _ctx.Database.BeginTransactionAsync(ct);
        try
        {
            _ctx.Tasks.RemoveRange(project.Tasks);  // cascade: tasks first
            await _repo.DeleteAsync(project);
            await _ctx.SaveChangesAsync(ct);

            await tr.CommitAsync(ct);
            return true;
        }
        catch
        {
            await tr.RollbackAsync(ct);
            throw;
        }
    }
}