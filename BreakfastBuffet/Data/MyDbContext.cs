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

       
        public DbSet<CheckIn> checkIn => Set<CheckIn>();
        public DbSet<Reservation> reservation => Set<Reservation>();

        public DbSet<Adult> adult => Set<Adult>();

        public DbSet<Child> children => Set<Child>();
    }
}
