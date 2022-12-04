namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class EncryptedFieldsOutput
    {
        public string Content { get; set; }
        public string Image { get; set; }
        public List<EncryptedMediaSet> Media { get; set; }
        public string Animation_url { get; set; }
        public string External_url { get; set; }
    }
}