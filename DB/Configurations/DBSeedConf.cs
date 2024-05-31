using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Configurations
{
    public static class DBSeedConf
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() {Id = 1, Name = "Fantasy"},
                new Genre() {Id = 2, Name = "Science Fiction"},
                new Genre() {Id = 3, Name = "Adventure"},
                new Genre() {Id = 4, Name = "Romance"},
                new Genre() {Id = 5, Name = "Thriller"}
            });
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Username = "voinore1", Password = "1", IsAdmin = true });
        }
    }
}