using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class VGAService : IVGAService
    {
        private readonly ApplicationDbContext _context;

        public VGAService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<VGADevices> GetAllVGADevices()
        {
            return _context.VGADevices.ToList();
        }
    }
}
