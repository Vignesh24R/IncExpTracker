using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer.DTO;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models.DTO;
using Business_Logic_Layer.Interfaces;

namespace IncExpTracker_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;

        

        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userBLL.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                var existingUser = await _userBLL.GetUserByEmail(user.EmailId);
                if (existingUser != null)
                {
                    return Conflict($"EmailId '{user.EmailId}' already exists.");
                }

                var createdUser = await _userBLL.CreateUser(user);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            try
            {
                var existingUser = await _userBLL.GetUserById(id);
                if (existingUser == null)
                    return NotFound();

                var updatedUser = await _userBLL.UpdateUser(user,id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update user with ID: {id}.");
            }
        }

        [HttpPost("Login")]
        public async Task<LoginResponseDTO> Login(LoginRequestDTO model)
        {
            var isAuthenticated = await _userBLL.Login(model.EmailId, model.Password);

            //if (isAuthenticated)
              //  return "Invalid email or password";

            return isAuthenticated;
        }

    }

}
