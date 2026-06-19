using Microsoft.EntityFrameworkCore;
using Form.Models;
using ModelData = Form.Models.Data;

namespace Form.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ModelData> Datas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
