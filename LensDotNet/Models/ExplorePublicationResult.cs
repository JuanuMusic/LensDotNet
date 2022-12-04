namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    //public record ExplorePublicationResult { 

    //    public record ExplorePostResult(
    //            List<Post> Items,
    //            PaginatedResultInfo PageInfo,
    //            PublicationTypes Types) : ExplorePublicationResult;

    //    public record ExploreCommentResult(
    //        List<ExploreCommentResult> Items,
    //        PaginatedResultInfo PageInfo,
    //        PublicationTypes Type) : ExplorePublicationResult;

    //    public record ExploreMirrorResult(
    //        List<ExploreMirrorResult> Items,
    //        PaginatedResultInfo PageInfo,
    //        PublicationTypes Type) : ExplorePublicationResult;

    //}   

    public class ExplorePublicationResult<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public PaginatedResultInfo? PageInfo { get; set; }
        PublicationTypes Type { get; set; }

        public ExplorePublicationResult() { }
    }

    public class ExplorePostResult : ExplorePublicationResult<Post>
    {

    }

    public class ExploreCommentResult : ExplorePublicationResult<Comment>
    {

    }
    public class ExploreMirrorResult : ExplorePublicationResult<Mirror>
    {

    }
}