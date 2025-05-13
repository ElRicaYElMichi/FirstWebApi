using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Response;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly DatabaseContext _context;
        
        public UserService(DatabaseContext context) {
            _context= context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
             var users=   await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetOneUser(int id)
        {
            return await _context.Users.FindAsync(id);

        }
        public async Task<User> AddUser(User user) {
            //pendiente agregar el id,la CreatedAt
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUser(int id , User user) {
            if (id != user.Id) return null;

            _context.Entry(user).State= EntityState.Modified;

            try { 
                await _context.SaveChangesAsync();
                return user;
            } catch (Exception ex) {
                if (!UserExists(id))
                {
                    return null;
                }
                throw;
            }
        }
        public async Task<User> DeleteUser(int id)
        {
            var user = await GetOneUser(id);
            if (user == null) return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return user;
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}
