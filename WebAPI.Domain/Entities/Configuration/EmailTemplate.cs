using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailTemplate : GenericEntity
{
    public string Description { get; set; }
    public virtual List<EmailDisplay> EmailDisplays { get; set; }

    public virtual EmailSettings EmailSettings { get; set; }
    public virtual long? IdEmailSettings { get; set; }
}
