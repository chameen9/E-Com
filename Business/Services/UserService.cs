using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Com.Business.Services

{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<User> GetAllUsers()
        {
            var users = _context.User.Where(c => c.DeletedAt == null)
                .Include(c => c.UserTypes)
                .ToList();
            return users;
        }
        public User CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;

            var thisUserType = _context.UserTypes.Where(x => x.TypeId == user.TypeId).FirstOrDefault();
            user.UserTypes = thisUserType;

            _context.User.Add(user);
            _context.SaveChanges();

            return user;
        }
        public void UpdateUser(string UserId, string Username, string Paswword, int TypeId)
        {
            var existingUser = _context.User.Where(x => x.UserId == UserId).FirstOrDefault();
            if (existingUser != null)
            {
                existingUser.Username = Username;
                existingUser.Paswword = Paswword;
                existingUser.TypeId = TypeId;
                existingUser.ModifiedAt = DateTime.Now;
                _context.Entry(existingUser).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public User GetUserById(string? id)
        {
            if (id == null || _context.User == null)
            {
                return null;
            }

            var user = _context.User
                .Where(m => m.UserId == id)
                .Include(c => c.UserTypes)
                .FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
