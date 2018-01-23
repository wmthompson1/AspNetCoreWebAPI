using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI.Entities
{
    // 1/22 the entity name here was changed to Survey to match db
    public class SqlDbContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Survey { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
        {
        }


    }
}
