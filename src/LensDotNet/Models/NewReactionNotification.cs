namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NewReactionNotification
    {
        public string NotificationId { get; set; }
        public string CreatedAt { get; set; }
        public Profile Profile { get; set; }
        public ReactionTypes Reaction { get; set; }
        public Publication Publication { get; set; }
    }
}