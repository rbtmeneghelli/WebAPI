﻿using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.Others;

public class Audit : GenericEntity
{
    public string TableName { get; set; }
    public string ActionName { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
}
