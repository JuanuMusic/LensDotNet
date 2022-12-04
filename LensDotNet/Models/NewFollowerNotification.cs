namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NewFollowerNotification
    {
        public string NotificationId { get; set; }
        public string CreatedAt { get; set; }
        public Wallet Wallet { get; set; }
        public bool IsFollowedByMe { get; set; }
    }
}