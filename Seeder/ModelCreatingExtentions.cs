using KarTech.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarTech.Seeder
{
    public static class ModelCreatingExtentions
    {
        public static async Task SeedAsync(this ModelBuilder modelBuilder)
        {
            GetCpuList getCpu = new GetCpuList();
            GetGpuList getGpu = new GetGpuList();
            List<CPU> Cpus = await getCpu.CpuList();
            List<GPU> Gpus = await getGpu.GpuList();
            

            modelBuilder.Entity<CPU>().HasData(Cpus);
            modelBuilder.Entity<GPU>().HasData(Gpus);
        }
    }
}
