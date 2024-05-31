using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class LineChart
    {
        public IEnumerable<ChartDataSets> ArrDataSets { get; set; }
        public string[] Labels { get; set; }
        public ChartOptions Options { get; set; }
        public bool ChartLegend { get; set; }
        public string ChartType { get; set; }
        public IEnumerable<ChartColors> ArrColors { get; set; }
    }
}
