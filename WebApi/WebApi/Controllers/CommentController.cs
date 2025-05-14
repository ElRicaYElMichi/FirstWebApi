using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }
        //post api/comment
        [HttpPost]
        public async Task<ActionResult<Response<Comment>>> AddComment([FromBody] Comment comment)
        {
            var response= new Response<Comment>();
            try {
                var newComment = await _commentService.AddComment(comment);

                if (newComment == null) {
                    response.Success = false;
                    response.Message = "Comment not add";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "Comment add successfully";
                return Ok(response);
                
            }catch(Exception ex) { 
                response.Success= false;
                response.Message = ex.Message;  
                return StatusCode(500,response);
            }
        }


        //Get api/comment
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Comment>>> EditComment(int id,[FromBody] string newContent)
        {
            var response = new Response<Comment>();
            try {
                var editComment = await _commentService.EditComment(id, newContent);

                if (editComment == null) {
                    response.Success = false;
                    response.Message = $"Comment with ID:{id} not found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "Comment updated successfully";
                return Ok(response);
                
            } catch(Exception ex) { 
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500,response);
            }
        }

        //Delete api/comment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var response = new Response<Comment>();
            try {
                var comment= await _commentService.DeleteComment(id);

                if (comment == null)
                {
                    response.Success = false;
                    response.Message = $"Comment with ID:{id} not found";
                    return BadRequest(response);
                    
                }
                response.Success = true;
                response.Message = $"Comment Id:{id} deleted successfully";
                return Ok(response);


            } catch (Exception ex) {
                response.Success= false;
                response.Message = ex.Message; 
                return StatusCode(500,response);
            }
        }
    }
}
