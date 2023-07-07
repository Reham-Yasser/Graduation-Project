using API.Dtos;
using AutoMapper;
using DAL.Entities;
using DAL.Entities.Identity;
using Edu_Chatbot.DTOS;

namespace Edu_Chatbot.Helper
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {

            CreateMap<Courses, CoursesDto>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();
                //.ForMember(b => b.Image, O => O.MapFrom<PictureUrlResolver>());
            CreateMap<Tracks, TracksDto>().ReverseMap();


        }


    }
}
