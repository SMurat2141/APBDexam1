namespace APBDProject.API.DTOs;

public record TaskDto(
    int      Id,
    string   Name,
    string?  Description,
    DateTime Deadline,
    string   ProjectName,
    string   TaskType);