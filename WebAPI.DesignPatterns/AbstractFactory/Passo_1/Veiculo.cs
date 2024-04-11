namespace WebAPI.DesignPatterns.AbstractFactory.Passo_1;

// AbstractProduct  
public abstract class Veiculo
{
    protected Veiculo(string modelo, Porte porte)
    {
        Modelo = modelo;
        Porte = porte;
    }

    public string Modelo { get; set; }
    public Porte Porte { get; set; }
}