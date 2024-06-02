using AutoMapper;
using SchoolBooks.Entities;
using SchoolBooks.Services.DTO.Pupils;
using SchoolBooks.Services.DTO.SchoolBook;

namespace SchoolBooks.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, SchoolBookDTORead>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class));

            CreateMap<Pupil, PupilsDtoRead>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.SurName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
