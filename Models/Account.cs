using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoWebVale.Models
{
    public class Account : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Initials { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}