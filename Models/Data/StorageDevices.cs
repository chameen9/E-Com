using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class StorageDevices
    {
        [Key]
        public int StorageDeviceId { get; set; }
        public string StorageDeviceName { get; set; }
        public string StorageDeviceType { get; set; }
        public string StorageDeviceCapacity { get; set;}
        public List<Products> Products { get; set; }
    }
}
