using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class BarChart
    {
        public string[] Labels { get; set; }
        public string ChartType { get; set; }
        public bool ChartLegend { get; set; }
        public List<ChartDataSets> ArrDataSets { get; set; }
    };
}
