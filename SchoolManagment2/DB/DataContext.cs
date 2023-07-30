using Microsoft.EntityFrameworkCore;
using SchoolManagment2.Models;

namespace SchoolManagment2.DB
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
       public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet <Class> Classes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mehedi> Mehedis { get; set; }
    }
}
