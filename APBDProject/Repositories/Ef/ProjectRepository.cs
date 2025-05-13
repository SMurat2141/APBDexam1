using Microsoft.EntityFrameworkCore;
using APBDProject.API.Data;
using APBDProject.API.Entities;
using APBDProject.API.Repositories.Interfaces;

namespace APBDProject.API.Repositories.Ef;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _ctx;
    public ProjectRepository(AppDbContext ctx) => _ctx = ctx;

    public Task<Project?> GetAsync(int id, CancellationToken ct = default) =>
        _ctx.Projects.Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.IdProject == id, ct);

    public Task DeleteAsync(Project project)
    {
        _ctx.Projects.Remove(project);
        return Task.CompletedTask;
    }
}