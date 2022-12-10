namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using GraphQL.Query.Builder;
    using Newtonsoft.Json;

    public partial class CreateFollowEIP712TypedDataTypes
    {
        [IgnoreFormatter]
        public List<EIP712TypedDataField> FollowWithSig { get; set; }
    }
}