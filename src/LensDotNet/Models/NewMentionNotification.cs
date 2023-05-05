namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NewMentionNotification
    {
        public string NotificationId { get; set; }
        public string CreatedAt { get; set; }
        public MentionPublication MentionPublication { get; set; }
    }
}