using API.Dtos;
using AutoMapper;
using BLL.Interfaces;
using Core.Interfaces;
using DAL.Entities;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, ITokenService tokenService)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
             _userManager = userManager;
            _tokenService= tokenService;
        }

        [HttpGet]
        [Route("current-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppUser>> GetCurrentUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return NotFound("Email can not be null or empty");
            }


            var user = await _userManager.FindByEmailAsync(email);
            var data = _mapper.Map<AppUser, UserDto>(user);

            var userDto = new UserDto
            {
                Display_Name = data.Display_Name,
                Email = data.Email,
                age = data.age,
                Image=data.Image,
                user_Level = data.user_Level,
                user_Track = data.user_Track,
                Job = data.Job,
                Token = await _tokenService.CreateToken(user, _userManager)


            };
         
         
            return Ok(userDto);
        }
    }
}
