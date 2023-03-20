using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class MemoryDevices
    {
        [Key]
        public int MemoryDeviceId { get; set; }
        public string MemoryBrand { get; set; }
        public string MemoryName { get; set; }
        public string MemoryType { get; set; }
        public string MemoryCapacity { get; set; }

        public List<Products> Products { get; set; }
    }
}
