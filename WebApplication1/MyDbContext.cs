using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) { 

        
        }
    }
}
