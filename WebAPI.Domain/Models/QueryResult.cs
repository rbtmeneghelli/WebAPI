using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class QueryResult<TEntity> where TEntity : class
    {
        public int Count { get; set; }
        public List<TEntity> Result { get; set; }
    }
}
