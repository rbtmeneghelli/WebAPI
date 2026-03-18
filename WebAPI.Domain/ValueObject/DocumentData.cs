namespace WebAPI.Domain.ValueObject;

public sealed record DocumentData
{
    public string Document { get; set; }
    public EnumDocumentType Type { get; set; }

    private DocumentData(string document, EnumDocumentType type)
    {
        if (string.IsNullOrEmpty(Document))
            throw new ArgumentException("Número do documento é obrigatório");

        Document = Normalize(document);
        Type = type;

        ValidateDocument();
    }

    public static DocumentData Create(string document, EnumDocumentType type) => new(document, type);

    private string Normalize(string document) => new string(document.Where(char.IsLetterOrDigit).ToArray());

    private void ValidateDocument()
    {
        switch (Type)
        {
            case EnumDocumentType.CPF:
                if (Document.Length < 11)
                    throw new ArgumentException("CPF inválido");
                break;

            case EnumDocumentType.RG:
                if (Document.Length < 5)
                    throw new ArgumentException("RG inválido");
                break;

            case EnumDocumentType.CNH:
                if (Document.Length != 11)
                    throw new ArgumentException("CNH inválido");
                break;

            case EnumDocumentType.Passaporte:
                if (Document.Length < 6)
                    throw new ArgumentException("Passaporte inválido");
                break;
        }
    }

    public override string ToString() => $"{Type}: {Document}";

}