using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities.User;

namespace MyRecipeBook.Infrastructure.DataAccess
{
    public class MyRecipeBookDbContext: DbContext
    {


        public MyRecipeBookDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbContext).Assembly);
        }

    }
}
