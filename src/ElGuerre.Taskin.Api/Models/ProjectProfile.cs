// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Models;

namespace ElGuerre.Taskin.Api.Models
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {

            CreateMap<ProjectModel, ProjectEntity>()
                .ForMember(dest => dest.ProjectType, opt => opt.Ignore());
                
            CreateMap<ProjectEntity, ProjectModel>()
                .ForMember(dest => dest.ProjectType, opt => opt.Ignore());

            //CreateMap<ProjectModel, ProjectEntity>()
            //    .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            //CreateMap<ProjectEntity, ProjectModel>()
            //    .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
        }
    }
}
