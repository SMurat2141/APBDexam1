namespace APBDProject.API.Services.Interfaces;

public interface IProjectService
{
    /// <summary>
    /// Deletes a project together with all its tasks in one transaction.
    /// Returns <c>true</c> when the project was found and deleted, <c>false</c> otherwise.
    /// </summary>
    Task<bool> DeleteProjectAsync(int id, CancellationToken ct = default);
}