namespace WebAPI.Domain.Models.Factory.Charts;

public abstract class GraphicModel
{
    public string Name;
    public string Description;
    public string[] Labels { get; set; }
    public string ChartType { get; set; }
    public bool ChartLegend { get; set; }
    public IEnumerable<ChartDataSets> ArrDataSets { get; set; }
    public ChartOptions Options { get; set; }
    public IEnumerable<ChartColors> ArrColors { get; set; }

    public GraphicModel()
    {
    }

    protected virtual void SetName(string name) => Name = name;
    protected virtual void SetDescription(string description) => Description = description;
}