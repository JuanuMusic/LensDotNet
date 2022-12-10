namespace LensDotNet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Notification
    {
        public NewFollowerNotification NewFollowerNotification { get; set; }
        public NewCollectNotification NewCollectNotification { get; set; }
        public NewCommentNotification NewCommentNotification { get; set; }
        public NewMirrorNotification NewMirrorNotification { get; set; }
        public NewMentionNotification NewMentionNotification { get; set; }
        public NewReactionNotification NewReactionNotification { get; set; }
    }
}