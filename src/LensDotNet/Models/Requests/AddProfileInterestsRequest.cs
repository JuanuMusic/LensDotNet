namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AddProfileInterestsRequest
    {
        public List<string> Interests { get; set; }
        public string ProfileId { get; set; }
    }
}