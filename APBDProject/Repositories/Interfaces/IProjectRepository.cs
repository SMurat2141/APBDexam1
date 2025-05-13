using APBDProject.API.Entities;

namespace APBDProject.API.Repositories.Interfaces;

public interface IProjectRepository
{
    Task<Project?> GetAsync(int id, CancellationToken ct = default);
    Task DeleteAsync(Project project);
}