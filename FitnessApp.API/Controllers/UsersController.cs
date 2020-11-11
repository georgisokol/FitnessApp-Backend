using AutoMapper;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using FitnessApp.API.utils;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult RegisterNewUser(string username, string password)
        {
            var user = _macrosRepository.GetUserByUsername(username);
            if(user != null)
            {
                return NotFound("The username is taken");

            }

            var salt = Convert.ToBase64String(Common.GetRandomSalt(16));
            var finalUserDto = new UserDto()
            {
                Username = username,
                Salt = salt,
                Password = Convert.ToBase64String(Common.SaltHashPassword(Encoding.ASCII.GetBytes(password), Convert.FromBase64String(salt)))
            };

            var finalUser = _mapper.Map<Entities.Users>(finalUserDto);

            _macrosRepository.RegisterUser(finalUser);
            _macrosRepository.Save();

            return Ok("Register Successfully");
        }

        [HttpPost("", Name ="GetUsers")]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            var finalUserDto = new UserDto() {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Age = user.Age,
                Gender = user.Gender,
                Height = user.Height,
                Weight= user.Weight,
                Frequency = user.Frequency,
                Type = user.Type,
                Goal = user.Goal
            };

            var finalUser = _mapper.Map<Entities.Users>(finalUserDto);

            _macrosRepository.AddUser(finalUser);
            _macrosRepository.Save();

            return CreatedAtRoute("GetUsers", finalUserDto);
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
                Goal = userForUpdate.Goal
            };

            _mapper.Map(finalUserDto, userEntity);
            _macrosRepository.Save();

            return NoContent();
        }

    }
}
