using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KarTech.Data.Models;
using KarTech.Seeder;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
