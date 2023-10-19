using Microsoft.EntityFrameworkCore;

namespace school.models
{
    public class schooldbcontext : DbContext
    {
        public DbSet<student> students { get; set; }
        public DbSet<classroom> classrooms { get; set; }
        public DbSet<reportcard> reportcards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string desktopaddress = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            optionsBuilder.UseSqlite($"Data Source={desktopaddress}\\school.db;");
        }
    }
}
