using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class UserSavedPosts
    {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual Posts Post { get; set; }
    }
}
