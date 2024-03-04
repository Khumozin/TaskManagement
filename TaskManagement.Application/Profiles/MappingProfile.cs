using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain;
using TaskManagement.Application.DTOs.Task;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskEntity, TaskDTO>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskDTO>().ReverseMap();
        }
    }
}
