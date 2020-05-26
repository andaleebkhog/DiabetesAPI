using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class QuestionDoctorsMention
    {
        public QuestionDoctorsMention()
        {
            NotificationAsked = new HashSet<NotificationAsked>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public bool? Status { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Questions Question { get; set; }
        public virtual ICollection<NotificationAsked> NotificationAsked { get; set; }
    }
}
