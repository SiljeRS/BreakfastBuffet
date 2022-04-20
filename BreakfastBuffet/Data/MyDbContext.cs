using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BreakfastBuffet.Models;

namespace BreakfastBuffet.Data
{
    public class MyDbContext : IdentityDbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

       
        public DbSet<Reservation> Reservation => Set<Reservation>();

        public DbSet<Adult> adult => Set<Adult>();

        public DbSet<Child> children => Set<Child>();

        public DbSet<Breakfast> Breakfast => Set<Breakfast>();

        public DbSet<CheckInOverview> CheckInOverview => Set<CheckInOverview>();
    }
}
