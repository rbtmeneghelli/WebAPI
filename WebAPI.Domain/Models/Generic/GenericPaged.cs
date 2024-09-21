﻿namespace WebAPI.Domain.Models.Generic;

public abstract class GenericPaged
{
    public int? NextPage { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int PageCount { get; set; }
}
