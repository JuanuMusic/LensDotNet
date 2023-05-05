namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    public partial class MediaSet : DynamicObject
    {
        public Media Original { get; set; }
    }
}