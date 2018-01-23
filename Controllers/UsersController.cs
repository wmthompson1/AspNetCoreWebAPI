using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebAPI.Services;
//using AspNetCoreWebAPI.Dtos;
//Models folder here contains helpers and DTO's
//Acronyms are all uppercase
using AspNetCoreWebAPI.Models;
//using AspNetCoreWebAPI.Helpers;
//Models folder here contains helpers and DTO's
using Microsoft.Extensions.Options;
//using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AspNetCoreWebAPI.Entities;
using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreWebAPI.Controllers
{
    // William Thompson commented these out TODO: update ng client
    //  [Authorize]
    //   [Route("[controller]")]
    //[Route("api/users")]
    [EnableCors("CorsPolicy")]
   
    [Route("api/users")]
    public class UsersController : Controller
    {

        
        private IUserService _userService;
        private AutoMapper.IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            AutoMapper.IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        // [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDTO userDto)
        {
            var user = userDto;
            //var user = _userService.Authenticate(userDto.Username, userDto.Password);

            //if (user == null)
            //    return Unauthorized();

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = "something " //tokenString
            });
        }

        // [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserDTO userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);

            try
            {
                // save 
                _userService.Create(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

 
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var users = _userService.GetAll();
                var userDtos = _mapper.Map<IList<UserDTO>>(users);
                return Ok(userDtos);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

                return BadRequest(new { error = ex.Message });
            }



        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserDTO userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                _userService.Update(user, userDto.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}