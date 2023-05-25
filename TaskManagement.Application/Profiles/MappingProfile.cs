using AutoMapper;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Domain;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Tasks, TasksDto>().ReverseMap();

            CreateMap<Tasks, CreateTasksDto>().ReverseMap();
            CreateMap<Tasks, UpdateTasksDto>().ReverseMap();

            CreateMap<CheckList, CheckListDto>().ReverseMap();

            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();
            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();

            
        }
        
    }
}