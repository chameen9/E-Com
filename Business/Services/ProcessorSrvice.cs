using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class ProcessorSrvice : IProcessorSrvice
    {
        private readonly ApplicationDbContext _context;

        public ProcessorSrvice(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Processors> GetAllProcessors()
        {
            return _context.Processors.ToList();
        }
    }
}
