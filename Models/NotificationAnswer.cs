using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class NotificationAnswer
    {
        public int NotificationId { get; set; }
        public int AnswerId { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
