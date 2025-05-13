using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) {
            _userService = userService;
        }
        //GET: api/user
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<User>>>> GetAllUsers() {
            var response = new Response<IEnumerable<User>>();
            try {
                var users = await _userService.GetAllUsers();

                if (users == null) {
                    response.Success = false;
                    response.Message = "None User Found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "All User Found successfully";
                response.Data = users;
                return Ok(response);

            } catch (Exception ex) {

                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500,response);
            }
        }

        //Get:  api/User/id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var response = new Response<User>();
            try {
                var user = await _userService.GetOneUser(id);
                
                if (user== null) { 
                    response.Success=false;
                    response.Message = $"User with ID : {id} not found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "User Found successfully";
                response.Data = user;
                
                return Ok(response);

            } catch (Exception ex) { 
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500,response);
            }
        }

        //Put: api/user/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<User>>> PutUser(int id, User user)
        {
            var response = new Response<User>();
            try {
                var updateUser = await _userService.UpdateUser(id, user);

                if(updateUser == null)
                {
                    response.Success = false;
                    response.Message = $"User with ID : {id} not found";
                    return NotFound(response);
                }

                response.Success = true;
                response.Message = "User updated successfully.";
                response.Data = updateUser;
                return Ok(response);

            } catch (Exception ex) {

                response.Success=false;
                response.Message =ex.Message;
                return BadRequest(response);

            }
        }
        //POST: api/user
        [HttpPost]
        public async Task<ActionResult<Response<User>>> PostUser(User user) {
            var response = new Response<User>();

            try {
                var newUser = await _userService.AddUser(user);
                if(newUser== null)
                {
                    response.Success = false;
                    response.Message = "User not Add";
                    return BadRequest(response);
                }
                response.Success = true;
                response.Message = "Person add successfully.";
                response.Data = newUser;

                return Ok(response);


            } catch (Exception ex) {
            
                response.Success=false;
                response.Message = ex.Message;
                return StatusCode(500,response);
            }
        }
        //Delete api/user/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new Response<User>();
            try
            {
                var user = await _userService.DeleteUser(id);

                if(user == null)
                {
                    response.Success = false;
                    response.Message = $"Person with ID: {id} not found.";
                    return NotFound(response);
                }

                response.Success = true;
                response.Message = $"Person Id: {id} deleted successfully";
                response.Data = user;
                return Ok(response);

            }catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Person with ID: {id} not found.";
                return StatusCode(500,response);
            }
        }
        
    }
}
