namespace APBDProject.API.Entities;

public class TeamMember
{
    public int    IdTeamMember  { get; set; }
    public string FirstName     { get; set; } = default!;
    public string LastName      { get; set; } = default!;
    public string Email         { get; set; } = default!;

    public ICollection<TaskEntity> TasksAssigned { get; set; } = new List<TaskEntity>();
    public ICollection<TaskEntity> TasksCreated  { get; set; } = new List<TaskEntity>();
}