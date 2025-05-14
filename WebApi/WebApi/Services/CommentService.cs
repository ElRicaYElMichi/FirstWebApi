using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services
{
    public class CommentService
    {
        private readonly DatabaseContext _context;
        public CommentService(DatabaseContext databaseContext) {
            _context = databaseContext;
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetOneComment(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> AddComment(Comment comment)
        {
               //agregar id y CreatedAt 
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> EditComment(int id, string newComment)
        {
            var comment = await GetOneComment(id);
            if (comment == null) return null;
           
            comment.Content = newComment;
            await _context.SaveChangesAsync();

            return comment;

        }

        public async Task<Comment> DeleteComment(int id)
        {
            var comment = await GetOneComment(id);
            if (comment == null) return null;

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;


        }
    }
}
