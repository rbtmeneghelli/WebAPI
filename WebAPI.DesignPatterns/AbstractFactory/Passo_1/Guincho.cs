namespace WebAPI.DesignPatterns.AbstractFactory.Passo_1;

// AbstractProduct   
public abstract class Guincho
{
    protected Guincho(Porte porte)
    {
        Porte = porte;
    }

    public abstract void Socorrer(Veiculo veiculo);
    public Porte Porte { get; set; }
}