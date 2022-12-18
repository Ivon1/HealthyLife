using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthyLife.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required, Display(Name = "OrderNumber")]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
