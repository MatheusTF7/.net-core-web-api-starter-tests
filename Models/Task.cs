using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using ProjetoWebVale.Utils;

namespace ProjetoWebVale.Models
{
    public class Task : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? DateStart { get; set; }

        [NotMapped]
        public string DateStartPtbr
        {
            get
            {
                return this.DateStart.ToString_ddMMyyyy();
            }
        }

        [NotMapped]
        public string DateEndPtbr
        {
            get
            {
                return this.DateEnd.ToString_ddMMyyyy();
            }
        }

        public DateTime? DateEnd { get; set; }

        [NotMappedAttribute]
        public bool isDone { get; set; } = false;

        public long AccountId { get; set; }

        // [JsonIgnore]
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public long UserId { get; set; }

        // [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}