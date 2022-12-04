namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NewCollectNotification
    {
        public string NotificationId { get; set; }
        public string CreatedAt { get; set; }
        public Wallet Wallet { get; set; }
        public Publication CollectedPublication { get; set; }
    }
}