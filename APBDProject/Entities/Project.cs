namespace APBDProject.API.Entities;

public class Project
{
    public int    IdProject   { get; set; }
    public string Name        { get; set; } = default!;
    public string? Description { get; set; }

    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}