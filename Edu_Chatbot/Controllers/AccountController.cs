using API.Dtos;
using AutoMapper;
using BLL.Interfaces;
using BLL.ModelService;
using Core.Interfaces;
using DAL.Entities;
using DAL.Entities.Identity;
using Edu_Chatbot.Controllers;
using Edu_Chatbot.DTOS;
using Edu_Chatbot.Errors;
using Edu_Chatbot.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager,
                                  SignInManager<AppUser> signInManager,
                                  ITokenService tokenService,IEmailService emailService,
                                  IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> login(LoginDto loginDto)
        { 

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(400, "email is not exist"));
            var password = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (password)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);

                var token = await _tokenService.CreateToken(user, _userManager);
                var message = "Logged Successfully";

                return Ok(new { token , message});

            }
            else { return BadRequest(new ApiResponse(400, "invalid passwor")); };
            }

            [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Regitser(RegisterDto registerDto)
        {

            var userExist = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExist != null)
            {
                return BadRequest(new ApiResponse(405));
            }

            var user = new AppUser
            {
                Display_Name = registerDto.DisplayName,
                UserName = registerDto.Email.Split("@")[0],
                Email = registerDto.Email,
                age = registerDto.age,
              
                SecurityStamp = Guid.NewGuid().ToString(),
                TwoFactorEnabled=true,
                Address = new Address
                {
                    FristName = registerDto.FristName,
                    LastName = registerDto.LastName,
                
                   
                }

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return Ok(new ApiResponse(200,"Register Successfly"));
        }




        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                      return StatusCode(StatusCodes.Status200OK,
                      new ApiResponse(200 , "Email Verified Successfully"));
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError,
                       new ApiResponse(500 , "This User Doesnot exist!"));

        }



        [HttpPost("ForgetPassword")]
        public async Task<ActionResult<ResetPassword>> ForgetPassword(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            
            if (user !=null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                
                var data = new ResetPassword { Token = token, Email = user.Email };

                return Ok(new { token , user.Email });



            }
            return Ok(new ApiResponse(400, $"Could not find this email , Please try again."));


        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> RestPassword(string token, string email)
        {

            var model = new ResetPassword { Token = token, Email = email };

            return Ok(new { model }) ;

        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> RestPassword(ResetPassword  resetPassword)
        {

           var user = await _userManager.FindByEmailAsync(resetPassword.Email);

            if(user != null)
            {
                var resetPassresult =await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);


                if (!resetPassresult.Succeeded)
                {
                    foreach (var error in resetPassresult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return Ok(ModelState);
                }

                return Ok(new ApiResponse(200, $"Password has been Changed successfully"));


            }

            return Ok(new ApiResponse(400, $"Could not reset the Password "));

        }




    }
}
