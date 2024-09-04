using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.ControlPanel;

/// <summary>
/// O Data Annotation [Owned] ajuda a modelar os dados que pertencem a uma entidade, mas não têm identidade própria
/// Com isso Podemos classificar que os dados das classes ClientCep quanto ClientDocument estão aninhados com a classe Principal Client
/// Com o uso do Owned evita-se o uso de efetuar o include, pois os dados irão vir implicitamente dentro da classe Principal Client por Eager Loading
/// Esse tipo de pratica é recomendado para dados do tipo Endereço ou Documento Pessoal
/// Link de referencia >> https://www.c-sharpcorner.com/article/reducing-complexity-using-entity-framework-core-owned-types/
/// 

/// Você pode usar o [Owned] em tipos complexos em situações como:
///Campos de Endereço: Se você tem uma classe de entidade que precisa armazenar informações de endereço(como rua, cidade, estado, CEP), você pode definir um tipo complexo para representar um endereço e marcar esse tipo com[Owned].
///Detalhes de Contato: Se uma classe de entidade precisar armazenar informações de contato(como telefone, e-mail, redes sociais), você pode criar um tipo complexo para isso e usar[Owned].
///Informações de Envio: Se uma classe de entidade precisar armazenar informações de envio(como método de envio, data de envio, informações do remetente), um tipo complexo marcado com[Owned] poderia ser apropriado.
///Detalhes Financeiros Simplificados: Se a entidade precisar armazenar alguns detalhes financeiros simples (como preço, moeda, impostos), você poderia usar um tipo complexo para encapsular essas informações.
///
/// A partir do NET 8 é possivel utilizar o complexType, Essa abordagem é conhecida como Value Object
/// </summary>
public class Client : GenericEntity
{
    public string ClientName { get; private set; }
    public Address ClientAddress { get; private set; }
    public Document ClientDocument { get; private set; }

    public Client() { }
    public Client(string clientName, Address clientAddress, Document clientDocument)
    {
        ClientName = clientName;
        ClientAddress = clientAddress;
        ClientDocument = clientDocument;
    }
}

//[Owned]
//[ComplexType]
public class Address
{
    public string Cep { get; set; }
    public string City { get; set; }

    public Address()
    {

    }

    public Address(string cep, string city)
    {
        Cep = cep;
        City = city;
    }
}

//[Owned]
//[ComplexType]
public class Document
{
    public required string Cpf { get; set; }
    public required string Rg { get; set; }
    public required DateTime BirthDate { get; set; }
    public required int Age { get; set; }

    public Document()
    {

    }

    public Document(string cpf, string rg, DateTime birthDate, int age)
    {
        Cpf = cpf;
        Rg = rg;
        BirthDate = birthDate;
        Age = age;
    }
}

