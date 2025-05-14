using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services
{
    public class ReactionService
    {
        private readonly DatabaseContext _context;

        public ReactionService(DatabaseContext context) {
            _context = context;

        }

        public async Task<IEnumerable<Reaction>> GetAllReactions()
        {
            return await _context.Reactions.ToListAsync();

        }

        public async Task<Reaction> getOneReaction(int id) {
            return await _context.Reactions.FindAsync(id);
        }

        public async Task<Reaction> AddReaction(Reaction reaction) {
            //agregar id y created 
            _context.Reactions.Add(reaction);
            await _context.SaveChangesAsync();
            return reaction;

        }

        public async Task<Reaction> UpdateReaction(int id, string reactionType)
        {
            var reaction = await getOneReaction(id);
            if (reaction == null) return null;

            reaction.Type = reactionType;
            await _context.SaveChangesAsync();
            return reaction;
        }


        public async Task<Reaction> DeleteReaction(int id)
        {
            var reaction= await getOneReaction(id);
            if (reaction == null) return null;

            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();

            return reaction;
        }

    }
}
