using KarTech.Data.Models;
using KarTech.Seeder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KarTech.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public DbSet<GPU> GPUs { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Computer> Computers { get; set; }

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            await modelBuilder.SeedAsync();
            await this.SaveChangesAsync();
        }
    }
}
//The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'.