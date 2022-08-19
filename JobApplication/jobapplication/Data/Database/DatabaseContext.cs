using jobapplication.Entity;
using Microsoft.EntityFrameworkCore;

namespace jobapplication.Data.Database{

    public class DatabaseContext : DbContext{
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)   
        { }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        
    }
}