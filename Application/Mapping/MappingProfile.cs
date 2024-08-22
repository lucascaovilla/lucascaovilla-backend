using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HomeBanner, HomeBannerDto>().ReverseMap();

            CreateMap<HomeAbout, HomeAboutDto>()
                .ForMember(dest => dest.TechnologyCards, opt => opt.MapFrom(src => src.TechnologyCards))
                .ReverseMap();

            CreateMap<TechnologyCard, TechnologyCardDto>().ReverseMap();

            CreateMap<HomePortfolio, HomePortfolioDto>()
                .ForMember(dest => dest.ProjectCards, opt => opt.MapFrom(src => src.ProjectCards))
                .ReverseMap();

            CreateMap<ProjectCard, ProjectCardDto>().ReverseMap();
        }
    }
}
