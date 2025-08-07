using AutoMapper;
using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using System.Reflection;

namespace BugTracker.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bug, BugRequestDTO>().ReverseMap();
            CreateMap<Bug, BugResponseDTO>();

            CreateMap<Project, ProjectRequestDTO>().ReverseMap();
            CreateMap<Project, ProjectResponseDTO> ();
        }
    }
}
