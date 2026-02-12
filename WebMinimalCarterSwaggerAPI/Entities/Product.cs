namespace WebMinimalCarterSwaggerAPI.Entities;

public class Product
{
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }

    public IEnumerable<string> ValidateProductCreation()
    {
        ICollection<string> ErrorMessages = new HashSet<string>();

        if (IsinvalidProductName())
            ErrorMessages.Add("Nome do produto é invalido");

        if (IsInvalidPrice())
            ErrorMessages.Add("Preço do produto é invalido");

        return ErrorMessages;
    }

    public IEnumerable<string> ValidateProductUpdate()
    {
        ICollection<string> ErrorMessages = new HashSet<string>();

        if (IsInvalidProductId())
            ErrorMessages.Add("Código do produto é invalido");

        if (IsinvalidProductName())
            ErrorMessages.Add("Nome do produto é invalido");

        if (IsInvalidPrice())
            ErrorMessages.Add("Preço do produto é invalido");

        return ErrorMessages;
    }

    private bool IsInvalidProductId() => !ProductId.HasValue && ProductId.GetValueOrDefault(0) <= 0;
    private bool IsinvalidProductName() => string.IsNullOrWhiteSpace(ProductName);
    private bool IsInvalidPrice() => Price <= 0;
}
