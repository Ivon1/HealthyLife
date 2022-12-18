using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HealthyLife.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required, Display(Name = "TextComment")]
        public string TextComment { get; set; } = string.Empty;

        [Required, Display(Name = "UserId")]
        public int UserId { get; set; }

        public virtual IdentityUser? IdentityUser { get; set; }
    }
}
