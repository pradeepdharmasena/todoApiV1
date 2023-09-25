using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using todoApiV1.models;

namespace todoApiV1.repository
{
    public class AppDbContext: DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<ToDo> ToDo { get; set; }

        public DbSet<Multimedia> Multimedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost; database=mydb; uid=root; password=Yatipasgama#1";
            
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.ToDos)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }

    }
}