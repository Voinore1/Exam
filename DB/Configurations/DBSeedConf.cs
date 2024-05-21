using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Configurations
{
    public static class DBSeedConf
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>().HasData(new Genres[]
            {
                new Genres() {Id = 1, Name = "Fantasy"},
                new Genres() {Id = 2, Name = "Science Fiction"},
                new Genres() {Id = 3, Name = "Adventure"},
                new Genres() {Id = 4, Name = "Romance"},
                new Genres() {Id = 5, Name = "Thriller"}
            });
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Username = "voinore1", Password = "1", IsAdmin = true });
        }
    }
}