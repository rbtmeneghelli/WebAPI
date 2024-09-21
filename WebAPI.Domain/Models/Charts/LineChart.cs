namespace WebAPI.Domain.Models.Charts;

public class LineChart
{
    public IEnumerable<ChartDataSets> ArrDataSets { get; set; }
    public string[] Labels { get; set; }
    public ChartOptions Options { get; set; }
    public bool ChartLegend { get; set; }
    public string ChartType { get; set; }
    public IEnumerable<ChartColors> ArrColors { get; set; }
}
