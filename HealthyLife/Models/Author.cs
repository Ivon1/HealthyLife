using System.ComponentModel.DataAnnotations;

namespace HealthyLife.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, Display(Name = "AuthorName")]
        public string AuthorName { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
