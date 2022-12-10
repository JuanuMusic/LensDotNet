namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Dispatcher
    {
        public string Address { get; set; }
        public bool CanUseRelay { get; set; }
    }
}