namespace WebAPI.Domain.Models.Charts;

public class BarChart
{
    public string[] Labels { get; set; }
    public string ChartType { get; set; }
    public bool ChartLegend { get; set; }
    public IEnumerable<ChartDataSets> ArrDataSets { get; set; }
};
