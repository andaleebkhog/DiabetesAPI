using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Answers = new HashSet<Answers>();
            Chat = new HashSet<Chat>();
            Msg = new HashSet<Msg>();
            Posts = new HashSet<Posts>();
            Questions = new HashSet<Questions>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string ImageSource { get; set; }
        public bool? Type { get; set; }
        public string Id { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
        public virtual ICollection<Msg> Msg { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
