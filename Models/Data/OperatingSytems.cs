using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class OperatingSytems
    {
        [Key]
        public int OSId { get; set; }
        public string OSBrand { get; set; }
        public string OSVersion { get; set; }
        public string? OSEdition { get; set; }

        public List<Products> Products { get; set; }
    }
}
