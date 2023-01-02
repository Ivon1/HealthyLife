using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthyLife.Models;

namespace HealthyLife.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<UserOrder> UserOrders { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = default!;
    }
}