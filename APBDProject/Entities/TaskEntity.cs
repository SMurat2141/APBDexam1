namespace APBDProject.API.Entities;

public class TaskEntity
{
    public int      IdTask       { get; set; }
    public string   Name         { get; set; } = default!;
    public string?  Description  { get; set; }
    public DateTime Deadline     { get; set; }

    public int        IdAssignedTo { get; set; }
    public TeamMember AssignedTo   { get; set; } = default!;

    public int        IdCreatedBy  { get; set; }
    public TeamMember CreatedBy    { get; set; } = default!;

    public int    IdProject { get; set; }
    public Project Project  { get; set; } = default!;

    public int      IdTaskType { get; set; }
    public TaskType TaskType   { get; set; } = default!;
}