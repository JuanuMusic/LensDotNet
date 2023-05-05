namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class NewMirrorNotification
    {
        public string NotificationId { get; set; }
        public string CreatedAt { get; set; }
        public Profile Profile { get; set; }
        public MirrorablePublication Publication { get; set; }
    }
}