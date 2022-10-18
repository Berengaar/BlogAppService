using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public static List<T> ToPagedList(IQueryable<T> source, PaginatedParameters paginatedParameters)
        {
            var x = source.Count();
            var items = source.Skip((paginatedParameters.PageNumber - 1) / paginatedParameters.PageSize)
                .Take(paginatedParameters.PageSize)
                .ToList();
            return new List<T>(items);
        }
    }
}
