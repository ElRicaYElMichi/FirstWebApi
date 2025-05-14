using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Models.Response;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService) {
            _postService = postService;
        }

        // Get api/post
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Post>>>> GetAllPosts()
        {
             var response = new Response<IEnumerable<Post>>();

            try {
                var posts = await _postService.GetAllPost();

                if(posts== null)
                {
                    response.Success = false;
                    response.Message = "None Post Found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "All Posts Found successfully";
                response.Data = posts;
                return Ok(response);
            }
            catch (Exception ex) { 
            
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
        }
        //GET api/post/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var response = new Response<Post>();
            try {
                var post = await _postService.GetOnePost(id);

                if (post == null)
                {
                    response.Success = false;
                    response.Message = $"Post with ID : {id} not found";
                    return BadRequest(response);
                }

                response.Success = true;
                response.Message = "Post Found successfully";
                response.Data = post;

                return Ok(response);



            }
            catch (Exception ex) { 
                response.Success= false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            
            }
        }

        //Post api/post
        [HttpPost]
        public async Task<ActionResult<Response<Post>>> AddPost([FromBody] Post post) { 
        
            var response = new Response<Post>();
            try {

                var newPost = await _postService.AddPost(post);

                if (newPost == null)
                {
                    response.Success = false;
                    response.Message = "Post not Add";
                    return BadRequest(response);
                }
                response.Success = true;
                response.Message = "Post add successfully.";
                response.Data = newPost;

                return Ok(response);

            }
            catch (Exception ex) { 
            
                response.Success=false;
                response.Message = ex.Message;
                return StatusCode(500, response);

            }
        }
        //Put api/post/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Post>>> EditPost(int id,[FromBody] string newContent) {
         
            var response = new Response<Post>();

            try {
                var editContent = await _postService.UpdatePost(id, newContent);
                if(editContent == null)
                {
                    response.Success = false;
                    response.Message= $"Post with ID : {id} not found";
                    return NotFound(response);
                }

                response.Success = true;
                response.Message = "Post updated successfully";
                return Ok(response);
                
            
            }catch(Exception ex) {
                response.Success=false;
                response.Message=ex.Message;
                return StatusCode(500, response);
            }
            
        }


        //delete api/post/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id ) {

            var response = new Response<Post>();
            try
            {
                var post = await _postService.DeletePost(id);

                if (post == null)
                {
                    response.Success = false;
                    response.Message = $"Post with ID: {id} not found.";
                    return NotFound(response);
                }

                response.Success = true;
                response.Message = $"Post Id: {id} deleted successfully";
                response.Data = post;
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                return StatusCode(500, response);
            }
        }
    }
}
