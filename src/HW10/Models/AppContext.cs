using Microsoft.EntityFrameworkCore;

namespace HW10.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
        
        public DbSet<ExpressionModel> ExpressionCache { get; set; }
    }
}