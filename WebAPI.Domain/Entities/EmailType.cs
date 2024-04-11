using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities;

public class EmailType : GenericEntity
{
    public string Description { get; set; }
    public string SmtpConfig { get; set; }
}
