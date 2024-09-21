using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Models.Generic;

namespace WebAPI.Domain.Models;

public class PagedResult<T> : GenericPaged where T : class
{
    public IEnumerable<T> Results { get; set; }

    public PagedResult()
    {
        Results = Enumerable.Empty<T>();
    }
}
