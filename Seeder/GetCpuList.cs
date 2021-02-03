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

        public GetCpuList()
        {
            listCpu = new List<CPU>();
        }
        public async Task<List<CPU>> CpuList()
        {
            using (var cpuStreamReader = new StreamReader("CPU_UserBenchmarks.csv"))
            {
              var titleGetter =  await cpuStreamReader.ReadLineAsync();

                while (!cpuStreamReader.EndOfStream)
                {
                    var line = await cpuStreamReader.ReadLineAsync();
                    var values = line.Split(",");

                    CPU cpu = new CPU()
                    {
                        Brand = values[2],
                        Model = values[3],
                        Rank = double.Parse(values[4]),
                        Benchmark = double.Parse(values[5])
                    };
                    listCpu.Add(cpu);
                }
                return listCpu;
            }
        }
    }
}
