using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProcessStatistics
{
    public class HopModel
    {
        [Display]
        public string Domain { get; set; }

        [Display]
        public int HopCount { get; set; }
    }
}
