using AutoMapper;
using APBDProject.API.Entities;
using APBDProject.API.DTOs;

namespace APBDProject.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //          Entity → DTO
        CreateMap<TaskEntity, TaskDto>()
            .ForMember(d => d.Id,          c => c.MapFrom(s => s.IdTask))
            .ForMember(d => d.ProjectName, c => c.MapFrom(s => s.Project.Name))
            .ForMember(d => d.TaskType,    c => c.MapFrom(s => s.TaskType.Name));

        CreateMap<TeamMember, TeamMemberDto>()
            .ForMember(d => d.Id,            c => c.MapFrom(s => s.IdTeamMember))
            .ForMember(d => d.TasksAssigned, c => c.MapFrom(s => s.TasksAssigned))
            .ForMember(d => d.TasksCreated,  c => c.MapFrom(s => s.TasksCreated));
    }
}