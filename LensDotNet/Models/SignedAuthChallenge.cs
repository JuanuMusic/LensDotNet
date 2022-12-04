namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SignedAuthChallenge
    {
        public string Address { get; set; }
        public string Signature { get; set; }
    }
}