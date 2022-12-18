using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HealthyLife.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }

        public List<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
    }
}
