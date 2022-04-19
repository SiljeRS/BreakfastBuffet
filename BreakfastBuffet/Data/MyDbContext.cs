using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BreakfastBuffet.Data
{
    public class MyDbContext : IdentityDbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }
    }
}
