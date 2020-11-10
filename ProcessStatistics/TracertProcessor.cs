using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ProcessStatistics
{
    public static class TracertProcessor
    {
        public static Task<HopModel[]> ProcessHops(params string[] domains)
        {
            List<Task<HopModel>> tasks = new List<Task<HopModel>>();
            foreach(var item in domains)
            {
                TaskCompletionSource<HopModel> tcs = new TaskCompletionSource<HopModel>();

                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo("tracert", item)
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    },

                    EnableRaisingEvents = true
                };
                p.Exited += (s, e) =>
                {
                    int hupcount = ((Process)s).StandardOutput.ReadToEnd().Split('\n').Length;
                    tcs.SetResult(new HopModel()
                    {
                        HopCount = hupcount,
                        Domain = item
                    });
                   
                };
                tasks.Add(tcs.Task);
                p.Start();
            }

            return Task.WhenAll(tasks);
        }

    }
}
