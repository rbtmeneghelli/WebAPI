namespace WebAPI.Domain.Attributes;

public sealed class TbAttribute : Attribute
{
    public string Name { get; set; }

    public TbAttribute(string name)
    {
        this.Name = name;
    }
}

public sealed class FieldAttribute : Attribute
{
    public string Name { get; set; }
    public bool Key { get; set; }

    public FieldAttribute(string name)
    {
        this.Name = name;
    }
}

public sealed class AuxFieldsAttribute
{
    public string Name { get; set; }
    public string Property { get; set; }
    public bool Key { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }

    public AuxFieldsAttribute()
    {

    }

    public AuxFieldsAttribute(bool key, string name, string property)
    {
        this.Key = key;
        this.Name = name;
        this.Property = property;
    }
}

/* Exemplo de Entidade ou Modelo utilizando os atributos acima para poder gerar script SQL
 * 
 *  [Tb("TB_CLIENT")]
 *  public class Client
 *  {
 *     [Field("CD_CLIENT", Key = true)]
 *      public string Id { get; set; }
 *     [Field("NM_CLIENT")]
        public string Name { get; set; }
 *  }     
 */
