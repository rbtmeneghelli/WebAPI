using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class ChartDataSets
    {
        public decimal[] Data { get; set; }
        public string Label { get; set; }
        public string[] BackgroundColor { get; set; }
        public string[] BorderColor { get; set; }
        public string[] PointBackgroundColor { get; set; }
    }
}
