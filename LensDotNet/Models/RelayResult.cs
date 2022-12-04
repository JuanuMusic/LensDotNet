namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class RelayResult
    {
        public RelayerResult RelayerResult { get; set; }
        public RelayError RelayError { get; set; }
    }
}