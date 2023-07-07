using API.Dtos;
using AutoMapper;
using DAL.Entities;
using DAL.Entities.Identity;
using Edu_Chatbot.DTOS;

namespace Edu_Chatbot.Helper
{
    public class PictureUrlResolver : IValueResolver<AppUser, UserDto, string>
    {
        private readonly IConfiguration configuration;

        public PictureUrlResolver(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string Resolve(AppUser source, UserDto destination, string destMember, ResolutionContext context)
        {
           // if (string.IsNullOrEmpty(destMember))
              //  return $"{configuration["ApiUrl"]}{source.Image}";
            return null;
        }

    }
}
