namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AndConditionInput
    {
        public List<AccessConditionInput> Criteria { get; set; }
    }
}