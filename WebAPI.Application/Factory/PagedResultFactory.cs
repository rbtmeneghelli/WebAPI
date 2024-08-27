namespace WebAPI.Application.Factory
{
    public static class PagedFactory
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.Page = ++page;
            result.PageSize = pageSize;
            result.TotalRecords = query.Count();
            result.PageCount = (int)Math.Ceiling((double)result.TotalRecords / pageSize);
            result.NextPage = (pageSize * result.Page) >= result.TotalRecords ? null : (int?)result.Page + 1;
            result.Results = query?.Count() > 0 ? query.Skip(GetPagination(result.Page, result.PageSize))
                                                       .Take(pageSize)
                                                       .AsEnumerable()
                                                       : Enumerable.Empty<T>();

            return result;
        }

        public static string AddFilters(List<PagedFilterModel> sqlConditions)
        {
            string filters = string.Empty;

            sqlConditions.ForEach(condition =>
            {
                if (condition.Value != null)
                {
                    filters += $@"
                        AND {condition.Column} ";

                    if (condition.Value.GetType() == typeof(string))
                        filters += $"LIKE '%' + {condition.Parameter} + '%'";
                    else if (condition.Value is IEnumerable<int> || condition.Value is IEnumerable<string>)
                        filters += $"IN {condition.Parameter}";
                    else
                        filters += $"= {condition.Parameter}";
                }
            });

            return filters;
        }

        public static string GetPagedTSqlPagination(string query, int page, int pageSize)
        {
            var newQuery = $"{query} " +
                           $"OFFSET ({page}-1) * {pageSize} ROWS " +
                           $"FETCH NEXT {pageSize} ROWS ONLY";

            return newQuery;
        }

        public static int GetDefaultPageIndex(int? pageIndex) => pageIndex.HasValue ? pageIndex.Value : 1;
        public static int GetDefaultPageSize(int? pageSize) => pageSize.HasValue ? pageSize.Value : 10;
        private static int GetPagination(int page, int pageSize) => (page - 1) * pageSize;

    }
}
