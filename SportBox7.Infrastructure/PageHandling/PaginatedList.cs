namespace SportBox7.Infrastructure.PageHandling
{
    using SportBox7.Application.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaginatedList<T> : List<T>, IPaginatedList<T>
    {
        private const int PageSize = 2;

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get => PageIndex > 1;
        }

        public bool HasNextPage
        {
            get => PageIndex < TotalPages;
        }

        public static Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex)
        {
            var count =  source.Count();
            var items =  source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
            return Task.Run(()=> new PaginatedList<T>(items, count, pageIndex, PageSize)) ;
        }
    }
}
