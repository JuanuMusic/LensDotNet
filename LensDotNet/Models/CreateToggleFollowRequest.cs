namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CreateToggleFollowRequest
    {
        public List<string> ProfileIds { get; set; }
        public List<bool> Enables { get; set; }
    }
}