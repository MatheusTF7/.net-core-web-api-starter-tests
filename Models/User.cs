using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProjetoWebVale.Models
{
    public class User : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [JsonIgnore]
        // [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [NotMappedAttribute]
        public string NewPassword { get; set; }

        // public string Type { get; set; }

        public long AccountId { get; set; }

        [JsonIgnore]
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}