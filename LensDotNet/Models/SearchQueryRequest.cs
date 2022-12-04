namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SearchQueryRequest
    {
        public string Limit { get; set; }
        public string Cursor { get; set; }
        public string Query { get; set; }
        public SearchRequestTypes Type { get; set; }
        public List<CustomFiltersTypes> CustomFilters { get; set; }
        public List<string> Sources { get; set; }
    }
}