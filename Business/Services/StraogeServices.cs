using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class StraogeServices : IStraogeServices
    {
        private readonly ApplicationDbContext _context;

        public StraogeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StorageDevices> GetAllStorageDevices()
        {
            return _context.StorageDevices.ToList();
        }
    }
}
