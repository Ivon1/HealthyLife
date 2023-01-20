using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HealthyLife.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;        
        public DateTime CreationTime { get; set; }
        public string PathToPhoto { get; set; } = string.Empty;

        public List<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
        public List<UserWish> UserWishes { get; set; } = new List<UserWish>();
    }
}
