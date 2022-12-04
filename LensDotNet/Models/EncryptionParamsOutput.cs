namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class EncryptionParamsOutput
    {
        public ProviderSpecificParamsOutput ProviderSpecificParams { get; set; }
        public EncryptionProvider EncryptionProvider { get; set; }
        public AccessConditionOutput AccessCondition { get; set; }
        public EncryptedFieldsOutput EncryptedFields { get; set; }
    }
}