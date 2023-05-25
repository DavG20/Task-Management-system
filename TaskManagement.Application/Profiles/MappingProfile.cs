using AutoMapper;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Domain;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Domain.Task, TasksDto>().ReverseMap();

            CreateMap<Domain.Task, CreateTasksDto>().ReverseMap();
            CreateMap<Domain.Task, UpdateTasksDto>().ReverseMap();

            CreateMap<CheckList, CheckListDto>().ReverseMap();

            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();
            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();




        }

    }
}