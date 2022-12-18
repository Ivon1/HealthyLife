using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyLife.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int OrderId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = new Order();

        [ForeignKey("CourseId")]
        public Course Course { get; set; } = new Course();
    }
}
