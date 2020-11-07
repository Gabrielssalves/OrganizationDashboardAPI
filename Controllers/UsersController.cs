using AutoMapper;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrganizationDashboardAPI.Data;
using OrganizationDashboardAPI.Dtos;
using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("userId", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(string userId)
        {
            var userItem = _repository.GetUserById(userId);

            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new { UserId = userReadDto.UserId }, userReadDto);
        }

        [HttpPut("userId")]
        public ActionResult<UserReadDto> UpdateUser (string userId, UserUpdateDto userUpdateDto)
        {
            var userModel = _repository.GetUserById(userId);
            if(userModel == null)
            {
                throw new ArgumentNullException();
            }

            _mapper.Map(userUpdateDto, userModel);

            _repository.UpdateUser(userModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
