namespace WebAPI.Domain.ValueObject;

public sealed record PersonData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set;}
    public DocumentData DocumentData { get; private set; }
    public string GetFullName() => $"{FirstName} {LastName}";
    public bool IsAdult() => Age >= 18 ? true : false;

    private PersonData(string firstName, string lastName, int age, DocumentData documentData)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("Número do documento é obrigatório");

        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("Número do documento é obrigatório");

        FirstName = firstName;
        LastName = lastName;
        Age = age;
        DocumentData = documentData;
    }

    public static PersonData Create(string firstName, string lastName, int age, DocumentData documentData) => new(firstName, lastName, age, documentData);

    public override string ToString() => $"{FirstName} {LastName}, {Age}, {DocumentData.Type}: {DocumentData.Document}";
}