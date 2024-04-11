namespace WebAPI.Domain.Models;

public class Report
{
    public int Modelo { get; set; }
    public int Formulario { get; set; }
    public int Tipo { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public string[] Period { get; set; }
    public string rootPath { get; set; }
}
