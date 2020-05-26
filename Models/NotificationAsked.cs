using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class NotificationAsked
    {
        public int NotificationId { get; set; }
        public int MentionId { get; set; }

        public virtual QuestionDoctorsMention Mention { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
