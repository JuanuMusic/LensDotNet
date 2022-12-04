namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Attribute
    {
        public string DisplayType { get; set; }
        public string TraitType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}