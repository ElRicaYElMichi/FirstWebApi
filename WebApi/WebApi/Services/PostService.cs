using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services
{
    public class PostService
    {
        private readonly DatabaseContext _context;
        public PostService(DatabaseContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetOnePost(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<Post> AddPost(Post post)
        {

            //agregar id y created 
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(int id , string newContent) { 
        
            var post = await GetOnePost(id);
            if (post == null) return null;

            post.Content = newContent;
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> DeletePost(int id)
        {
            var post = await GetOnePost(id);
            if (post == null) return null;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;

        }
    }
}
