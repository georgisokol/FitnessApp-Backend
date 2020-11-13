using AutoMapper;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using FitnessApp.API.utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FitnessApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController :ControllerBase
    {
        private readonly IMacrosRepository _macrosRepository;
        private readonly IMapper _mapper;

        public UsersController(IMacrosRepository macrosRepository, IMapper mapper)
        {
            _macrosRepository = macrosRepository ?? throw new ArgumentNullException(nameof(macrosRepository));
            _mapper = mapper;
        }




        [HttpGet("{userUid:guid}")]
        public IActionResult GetUsers([FromRoute] Guid userUid)
        {
            var user = _macrosRepository.GetUserByUid(userUid);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));

        }
        [HttpPost("")]
        public IActionResult RegisterNewUser([FromBody] UserAndPassDto usernameAndPasswordDto )
        {
            var user = _macrosRepository.GetUserByUsername(usernameAndPasswordDto.Username);
            if(user != null)
            {

                return NotFound(new { message = "Username already taken" });


            }

            var salt = Convert.ToBase64String(Common.GetRandomSalt(16));
            var finalUserDto = new UserDto()
            {
                UId = Guid.NewGuid(),
                Username = usernameAndPasswordDto.Username,
                Salt = salt,
                Password = Convert.ToBase64String(Common.SaltHashPassword(Encoding.ASCII.GetBytes(usernameAndPasswordDto.Password), Convert.FromBase64String(salt)))
            };

            var finalUser = _mapper.Map<Entities.Users>(finalUserDto);

            _macrosRepository.RegisterUser(finalUser);
            _macrosRepository.Save();

            return Ok(new { message = "Register Succesfully" });

        }

       [HttpPost("login")]
       public IActionResult LoginUser([FromBody] UserAndPassDto usernameAndPasswordDto)
        {
            var user = _macrosRepository.GetUserByUsername(usernameAndPasswordDto.Username);
            if(user == null)
            {
                
                return NotFound("The username does not exist");
            }

            var user_post_hash_password = Convert.ToBase64String(
                    Common.SaltHashPassword(Encoding.ASCII.GetBytes(usernameAndPasswordDto.Password), Convert.FromBase64String(user.Salt)));

            if (user_post_hash_password.Equals(user.Password))
            {
               
                return Ok(user.Uid);
            }
            else
            {
               
                return NotFound("Incorrect Password");
            }


        }

        [HttpPut("{userUid:guid}")]
        public IActionResult UpdateUser([FromRoute]Guid userUid, [FromBody] UserForUpdateDto userForUpdate)
        {
            var userEntity = _macrosRepository.GetUserByUid(userUid);

            if (userEntity == null)
            {
                return NotFound();
            }

            var finalUserDto = new UserDto()
            {
                UId = userUid,
                CreatedOn = DateTime.Now,
                Age = userForUpdate.Age,
                Gender = userForUpdate.Gender,
                Height = userForUpdate.Height,
                Weight = userForUpdate.Weight,
                Frequency = userForUpdate.Frequency,
                Type = userForUpdate.Type,
                Goal = userForUpdate.Goal,
                Username = userEntity.Username,
                Password = userEntity.Password,
                Salt = userEntity.Salt
            };

            _mapper.Map(finalUserDto, userEntity);
            _macrosRepository.Save();

            return NoContent();
        }

    }
}
