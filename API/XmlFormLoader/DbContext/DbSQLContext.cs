using XMLFormLoaderDemo.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace XMLFormLoaderDemo
{
    public class DbSQLContext : DbContext
    {
        public DbSQLContext(DbContextOptions<DbSQLContext> options) : base(options)
        {
        }
        public DbSet<UserAddress> Addresses { get; set; }
    }
}
