namespace SportBox7.Application.Contracts
{
    using System.Collections.Generic;

    public interface IPaginatedList<T>: IEnumerable<T>
    {
        int PageIndex { get; set; }
        int TotalPages { get; set; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

    }
}
