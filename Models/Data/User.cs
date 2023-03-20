using System.ComponentModel.DataAnnotations.Schema;

namespace E_Com.Models.Data
{
    public class User : PublicProps
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Paswword { get; set; }

        [ForeignKey("UserTypes")]
        public int TypeId { get; set; }
        public UserTypes UserTypes { get; set; }
    }
}
