using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class Msg
    {
        public Msg()
        {
            Chat = new HashSet<Chat>();
        }

        public int MsgId { get; set; }
        public int ChatId { get; set; }
        public DateTime Date { get; set; }
        public string MsgContent { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
