namespace WebMinimalAPI_Aot._3._Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string? FileName { get; private set; }

    public Product(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome inválido.");
        Name = name;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nome inválido.");
        Name = name;
    }

    public void SetFile(string filename) => FileName = filename;
}
