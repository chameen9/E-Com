using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class VGADevices
    {
        [Key]
        public int VGADeviceId { get; set; }
        public string VGABrand { get; set; }
        public string VGAVRAMSize { get; set; }
        public string VGARefreshRate { get; set; }


        public List<Products> Products { get; set; }
    }
}
