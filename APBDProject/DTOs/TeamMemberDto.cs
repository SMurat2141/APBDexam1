namespace APBDProject.API.DTOs;

public record TeamMemberDto(
    int                Id,
    string             FirstName,
    string             LastName,
    string             Email,
    IEnumerable<TaskDto> TasksAssigned,
    IEnumerable<TaskDto> TasksCreated);