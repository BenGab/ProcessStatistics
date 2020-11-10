using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace ProcessStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();

            var query = (from process in processes.AsEnumerable()
                         select (object)new ProcessStatistics
                         {
                             Name = process.ProcessName,
                             InstanceCount = 1,
                             AllMemory = process.PagedMemorySize64
                         }).ToList();

            var result = XmlGenerator.GenerateXml(query);

            var q2 = (from p in result.Descendants("process")
                     group p by p.Element("name").Value into grp
                     select new
                     {
                         Name = grp.Key,
                         Instances = grp.Count(),
                         AllMemory = grp.Sum(x=> long.Parse(x.Element("allmemory").Value))
                     }).ToList();

            var hopModel = TracertProcessor.ProcessHops("google.com", "index.hu").GetAwaiter().GetResult().Select(x=> (object)x).ToList();
           var xmlModel = XmlGenerator.GenerateXml(hopModel);
        }
    }
}
