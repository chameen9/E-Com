using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class ProcessorService : IProcessorService
    {
        private readonly ApplicationDbContext _context;

        public ProcessorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Processors> GetAllProcessors()
        {
            return _context.Processors.ToList();
        }
    }
}
