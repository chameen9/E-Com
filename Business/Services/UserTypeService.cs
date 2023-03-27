using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Com.Business.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly ApplicationDbContext _context;
        public UserTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserTypes> GetAllUserTypes()
        {
            var userTypes = _context.UserTypes.Where(c => c.DeletedAt == null)
                .ToList();
            return userTypes;
        }
    }
}
