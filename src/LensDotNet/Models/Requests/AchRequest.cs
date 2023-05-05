namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class AchRequest
    {
        public string Secret { get; set; }
        public string EthereumAddress { get; set; }
        public string Handle { get; set; }
        public bool? FreeTextHandle { get; set; }
        public bool OverrideTradeMark { get; set; }
        public bool OverrideAlreadyClaimed { get; set; }
    }
}