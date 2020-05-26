using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class NotificationFollow
    {
        public int NotificationId { get; set; }
        public int FollowId { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
