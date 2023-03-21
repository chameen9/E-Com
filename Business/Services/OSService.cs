using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class OSService : IOSService
    {
        private readonly ApplicationDbContext _context;

        public OSService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OperatingSytems> GetAllOperatingSystems()
        {
            return _context.OperatingSytems.ToList();
        }
    }
}
