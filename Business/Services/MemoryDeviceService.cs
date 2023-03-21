using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Com.Business.Services
{
    public class MemoryDeviceService : IMemoryDeviceService
    {
        private readonly ApplicationDbContext _context;

        public MemoryDeviceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MemoryDevices> GetAllMemoryDevices()
        {
            return _context.MemoryDevices.ToList();
        }
    }
}
