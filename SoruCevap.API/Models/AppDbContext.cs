using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoruCevap.API.DTOs;


namespace SoruCevap.API.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }

        DbSet<Label> Labels { get; set; }

        DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
