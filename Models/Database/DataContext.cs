using Microsoft.EntityFrameworkCore;

namespace TestingSystem.Models.Database
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}