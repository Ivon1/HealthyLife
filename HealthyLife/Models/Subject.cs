using System.ComponentModel.DataAnnotations;

namespace HealthyLife.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required, Display(Name = "SubjectName")]
        public string SubjectName { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
