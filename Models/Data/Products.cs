using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Web;

namespace E_Com.Models.Data
{
    public class Products : PublicProps
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }



        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set;}
        public ProductCategory ProductCategory { get; set; }



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

        public double Price { get; set; }

        public string ImageFileName { get; set; }

        [Required(ErrorMessage ="Please Choose an Image")]
        [Display(Name ="Image")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }

    }
}
