using System;
namespace LensDotNet.CoreTests.TestModels
{
    public partial class PaginatedProfileResult
    {
        public List<Profile> Items { get; set; }
        public PaginatedResultInfo PageInfo { get; set; }
    }

    public partial class PaginatedResultInfo
    {
        public string Prev { get; set; }
        public string Next { get; set; }
        public int? TotalCount { get; set; }
    }
}

