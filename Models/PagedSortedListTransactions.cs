namespace PFM.Models
{
    public class PagedSortedListTransactions<T>
    {
        public int PageSize { get; set; }

        public int Page { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public string SortBy { get; set; }

        public SortOrder SortOrder { get; set; }

        public List<T> Items { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TransactionKind? TransactionKind { get; set; }

    }
}
