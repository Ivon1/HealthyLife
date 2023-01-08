using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyLife.Models
{
    public class UserOrder
    {
        public int Id { get; set; }

        [Required , Display(Name = "CourseId")]
        public int CourseId { get; set; }

        [Required, Display(Name = "UserId")]
        public string UserId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set;}

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
