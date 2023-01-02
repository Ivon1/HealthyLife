using HealthyLife.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthyLife.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public List<Author> Authors { get; set; }
        public List<Subject> Subjects { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }    
}
