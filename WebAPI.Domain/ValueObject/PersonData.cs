namespace WebAPI.Domain.ValueObject;

public sealed record PersonData
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set;}
    public DocumentData documentData { get; private set; }
    public string GetFullName() => $"{FirstName} {LastName}";
    public bool IsAdult() => Age >= 18 ? true : false;

    public PersonData()
    {
            
    }

    public PersonData(string firstName, string lastName, int age, DocumentData documentData)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        this.documentData = documentData;
    }
}
