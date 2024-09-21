namespace WebAPI.Domain.Models.Charts;

public class PieChart
{
    public decimal[] ArrDataSets { get; set; }
    public string[] Labels { get; set; }
    public ChartOptions Options { get; set; }
    public bool ChartLegend { get; set; }
    public string ChartType { get; set; }
    public string[] ArrColors { get; set; }
}
