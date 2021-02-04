using KarTech.Data;
using KarTech.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KarTech.Seeder
{
    public class GetCpuList
    {
        private List<CPU> listCpu;
        private readonly string path = @"Seeder\Files\AllCpu.csv";
        public GetCpuList()
        {
            listCpu = new List<CPU>();
        }
        public async Task<List<CPU>> CpuList()
        {
            using var cpuStreamReader = new StreamReader(path);
            var titleGetter = await cpuStreamReader.ReadLineAsync();

            while (!cpuStreamReader.EndOfStream)
            {
                var line = await cpuStreamReader.ReadLineAsync();
                var values = line.Split(",");

                CPU cpu = new CPU()
                {
                    Id = int.Parse(values[0]),
                    Brand = values[1],
                    Model = values[2],
                    Rank = double.Parse(values[3]),
                    Benchmark = double.Parse($"{values[4]:f2}")
                };
                lock (this)
                {
                    listCpu.Add(cpu);
                }
            }
            return listCpu;
        }
    }
}
