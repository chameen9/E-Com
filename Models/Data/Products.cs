using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Com.Models.Data
{
    public class Products : PublicProps
    {
        [Key]
        public Guid ProductId { get; set; }

        [ForeignKey("Processors")]
        public int ProcessorTypeId { get; set; }
        public Processors Processors { get; set; }

        [ForeignKey("MemoryDevices")]
        public int MemoryDeviceId { get; set; }
        public MemoryDevices MemoryDevices { get; set; }

        [ForeignKey("VGADevices")]
        public int VGADeviceId { get; set; }
        public VGADevices VGADevices { get; set; }

        [ForeignKey("OperatingSytems")]
        public int OSId { get; set; }
        public OperatingSytems OperatingSytems { get; set; }

        [ForeignKey("StorageDevices")]
        public int StorageDeviceId { get; set; }
        public StorageDevices StorageDevices { get; set; }

    }
}
