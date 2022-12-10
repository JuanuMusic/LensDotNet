namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SetDispatcherRequest
    {
        public string ProfileId { get; set; }
        public string Dispatcher { get; set; }
        public bool? Enable { get; set; }
    }
}