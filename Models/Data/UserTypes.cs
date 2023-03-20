using System.ComponentModel.DataAnnotations;

namespace E_Com.Models.Data
{
    public class UserTypes : PublicProps
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public List<User> User { get; set; }
    }
}
