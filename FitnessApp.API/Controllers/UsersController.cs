using AutoMapper;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Controllers
{
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

        [HttpGet("api/users")]
        public IActionResult GetUsers()
        {
            var user = _macrosRepository.GetUsers();

            if(user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));

        }

        [HttpPost("api/users", Name ="GetUsers")]
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

        [HttpPut("api/users/{Uid}")]
        public IActionResult UpdateUser([FromRoute]Guid Uid, [FromBody] UserForUpdateDto userForUpdate)
        {
            var userEntity = _macrosRepository.GetUsers();
            if(userEntity == null)
            {
                return NotFound();
            }
            var finalUserDto = new UserDto()
            {
                UId = Uid,
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
