using AutoMapper;
using ControlActas.Models;
using ControlActas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Controllers.API
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private ILibraryRepository _repository;

        public UserController(ILibraryRepository repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllUsers();
                return Ok(Mapper.Map<IEnumerable<UserViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all users: {ex}");
                return BadRequest("Error Ocurred");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = Mapper.Map<User>(user);
                _repository.AddUser(newUser);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/users/{user.Name}", Mapper.Map<UserViewModel>(newUser));
                } else
                {
                    return BadRequest("Failed to save changes to database");
                }
            }

            return BadRequest("Bad data");
        }
    }
}
