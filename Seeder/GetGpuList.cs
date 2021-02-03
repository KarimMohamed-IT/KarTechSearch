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

            using (var gpuStreamReader = new StreamReader("GPU_UserBenchmarks.csv"))
            {
                //Removing the first line which is heading only
                var titlesGetter = await gpuStreamReader.ReadLineAsync();

                while (!gpuStreamReader.EndOfStream)
                {
                    var line = await gpuStreamReader.ReadLineAsync();
                    var values = line.Split(",");

                    GPU gpu = new GPU()
                    {
                        Brand = values[2],
                        Model = values[3],
                        Rank = double.Parse(values[4]),
                        Benchmark = double.Parse(values[5])
                    };
                    listGpu.Add(gpu);
                }
                return listGpu;
            }
        }
    }
}
