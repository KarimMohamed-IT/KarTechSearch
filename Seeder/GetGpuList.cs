using KarTech.Data;
using KarTech.Data.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KarTech.Seeder
{
    public class GetGpuList
    {
        private List<GPU> listGpu;

        public GetGpuList()
        {
            listGpu = new List<GPU>();
        }
        public async Task<List<GPU>> GpuList()
        {

            using var gpuStreamReader = new StreamReader(@"Seeder\Files\AllGpu.csv");

            //Removing the first line which is heading only
            var titlesGetter = await gpuStreamReader.ReadLineAsync();

            while (!gpuStreamReader.EndOfStream)
            {
                var line = await gpuStreamReader.ReadLineAsync();
                var values = line.Split(",");

                GPU gpu = new GPU()
                {
                    Id = int.Parse(values[0]),
                    Brand = values[1],
                    Model = values[2],
                    Rank = double.Parse(values[3]),
                    Benchmark = double.Parse($"{values[4]:f2}")
                };
                lock (this)
                {
                    listGpu.Add(gpu);
                }
            }
            return listGpu;
        }
    }
}
