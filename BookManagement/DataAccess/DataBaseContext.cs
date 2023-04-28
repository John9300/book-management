using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }
    }
}
