using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Data 
{
    public class DataContext : DbContext 
    {
        public DbSet<Dream> Dreams { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}