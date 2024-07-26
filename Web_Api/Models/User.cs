using System.ComponentModel.DataAnnotations;

namespace Web_Api.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        public required int Id { get; set; }
    }
}
