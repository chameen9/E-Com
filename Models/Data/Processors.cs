using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class Processors
    {
        [Key]
        public int ProcessorTypeId { get; set; }
        public string ProcessorBrand { get; set; }
        public string ProcessorType { get; set; }
        public string ProcessorGeneration { get; set; }
        public string ProcessorSpeed { get; set; }

        public List<Products> Products { get; set; }
    }
}
