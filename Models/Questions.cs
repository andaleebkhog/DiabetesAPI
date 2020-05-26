using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            QuestionDoctorsMention = new HashSet<QuestionDoctorsMention>();
        }

        public int QuestionId { get; set; }
        public DateTime? Date { get; set; }
        public string Question { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<QuestionDoctorsMention> QuestionDoctorsMention { get; set; }
    }
}
