using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace HealthyLife.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public string PathToPhoto { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Genger { get; set; } = string.Empty;

        public List<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
        public List<UserWish> UserWishes { get; set; } = new List<UserWish>();
    }
}
