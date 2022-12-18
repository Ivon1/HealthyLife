using System.ComponentModel.DataAnnotations;

namespace HealthyLife.ViewModels
{
    public class RoleUserVm
    {
        [Required, Display(Name = "User")]
        public string UserId { get; set; } = string.Empty;

        [Required, Display(Name = "Role")]
        public string RoleId { get; set; } = string.Empty;
    }
}
