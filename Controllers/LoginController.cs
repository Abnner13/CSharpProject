using System.Threading.Tasks;
using FProject.Domain.Entities;
using FProject.Domain.Interfaces;
using FProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace FProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController  : Controller
    {
        public IUserRepository _userRepository { get; set; }
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            try
            {
                var user = await _userRepository.Authenticate(model);

                if (!user)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var token = TokenService.GenerateToken(model);
                model.Password = "";

                return Ok(new {
                    user = model.Username,
                    token = token
                });

            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
