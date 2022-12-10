namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RemoveProfileInterestsRequest
    {
        public List<string> Interests { get; set; }
        public string ProfileId { get; set; }
    }
}