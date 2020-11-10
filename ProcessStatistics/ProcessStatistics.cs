using System.ComponentModel.DataAnnotations;

namespace ProcessStatistics
{
    public class ProcessStatistics
    {
        [Display]
        public string Name { get; set; }

        [Display]
        public int InstanceCount { get; set; }

        [Display]
        public long AllMemory { get; set; }
    }
}
