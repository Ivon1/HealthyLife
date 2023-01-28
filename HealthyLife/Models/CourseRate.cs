using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyLife.Models
{
    public class CourseRate
    {
        public int Id { get; set; }

        [Required, Display(Name = "Rate")]
        public int Rate { get; set; }

        [Required, Display(Name = "CourseId")]
        public int CourseId { get; set; }

        [Required, Display(Name = "UserId")]
        public string UserId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
