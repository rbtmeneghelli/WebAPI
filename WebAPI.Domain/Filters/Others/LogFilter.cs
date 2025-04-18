﻿using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record LogFilter : BaseFilterModel
{
    public string Class { get; set; }
    public string Method { get; set; }
}
