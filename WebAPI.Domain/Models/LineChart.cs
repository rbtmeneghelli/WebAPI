using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class LineChart
    {
        public List<ChartDataSets> ArrDataSets { get; set; }
        public string[] Labels { get; set; }
        public ChartOptions Options { get; set; }
        public bool ChartLegend { get; set; }
        public string ChartType { get; set; }
        public List<ChartColors> ArrColors { get; set; }
    }
}
