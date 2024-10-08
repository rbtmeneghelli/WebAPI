﻿using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Configuration;

public class EmailTemplate : GenericEntity
{
    public string Description { get; set; }
    public virtual List<EmailDisplay> EmailDisplays { get; set; }
}
