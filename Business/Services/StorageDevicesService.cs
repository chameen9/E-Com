using E_Com.Business.Interfaces;
using E_Com.Models.Data;
using E_Com.Data;

namespace E_Com.Business.Services
{
    public class StorageDevicesService : IStorageDevicesService
    {
        private readonly ApplicationDbContext _context;

        public StorageDevicesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Data.StorageDevices> GetAllStorageDevices()
        {
            return _context.StorageDevices.ToList();
        }
    }
}
