using FProject.Domain.Entities;
using FProject.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var usersList =  _userRepository.SelectAll();
                return Ok(usersList);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Username) || string.IsNullOrWhiteSpace(user.Username))
                {
                    return BadRequest("Username is required");
                }

                if(!(_userRepository.ExistsUsername(user.Username)))
                {
                    _userRepository.CreateUser(user);
                    return Ok("User created!!");
                }
                else
                    return BadRequest("Username ja utilizado");

            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUser([FromRoute] int Id)
        {
            try
            {
                var user = _userRepository.Get(Id);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return Ok("Usuario deleted");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, User model)
        {
            try
            {
                _userRepository.UpdateUser(id, model);
                return Ok("Usuario atualizado");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
