using GameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Score> Scores { get; set; }
    }
}
