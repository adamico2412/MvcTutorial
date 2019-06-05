using System;

namespace MvcTutorial.ViewModels
{
    public class QueryOptions
    {
        public string SortField { get; set; }
        public SortOrder SortOrder { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public string Sort
        {
            get
            {
                return String.Format("{0} {1}",
                    SortField, SortOrder.ToString());
            }
        }

        public QueryOptions()
        {
            SortField = "Id";
            SortOrder = SortOrder.ASC;
            CurrentPage = 1;
            PageSize = 5;
        }
    }
}