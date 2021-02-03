using KarTech.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KarTech.Seeder
{
    public static class ModelCreatingExtentions
    {
        private static readonly GetCpuList getCpu = new GetCpuList();
        private static readonly GetGpuList getGpu = new GetGpuList();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPU>().HasData(getCpu.CpuList());
            modelBuilder.Entity<GPU>().HasData(getGpu.GpuList());
        }
    }
}
