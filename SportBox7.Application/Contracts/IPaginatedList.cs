namespace SportBox7.Application.Contracts
{
    public interface IPaginatedList<T>
    {
        int PageIndex { get; set; }
        int TotalPages { get; set; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

    }
}
