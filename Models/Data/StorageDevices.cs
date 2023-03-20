using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class StorageDevices
    {
        [Key]
        public int StorageDeviceId { get; set; }
        public string StorageDeviceName { get; set; }
        public string StrageDeviceType { get; set; }
        public string StrageDeviceCapacity { get; set;}
    }
}
