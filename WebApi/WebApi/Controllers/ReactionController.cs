using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly ReactionService _reactionService;
        public ReactionController(ReactionService reactionService) { 
        _reactionService = reactionService;
        }

        //Get: api/user
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Reaction>>>> GetAllReaction()
        {
            var response = new Response<IEnumerable<Reaction>>();
            try {
                var reactions = await _reactionService.GetAllReactions();

                if(reactions == null)
                {
                    response.Success = false;
                    response.Message = "None Reaction Found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "All Reactions Found successfully";
                response.Data = reactions;
                return Ok(response);
            
            }catch(Exception ex) { 
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500,response);
            }
        }
    }
}
