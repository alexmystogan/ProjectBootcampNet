using Microsoft.EntityFrameworkCore;
using ProjectBootcampNet.Models;

namespace ProjectBootcampNet.DAL_Data_Access_Layer_
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentModel> Students { get; set; }

        public DbSet<CourseModel> Courses { get; set; }
    }
}
