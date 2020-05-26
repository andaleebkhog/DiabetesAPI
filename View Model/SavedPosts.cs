using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesAPI.View_Model
{
    public class SavedPosts
    {
        public int post_id { get; set; }
        public int user_id { set; get; }
        public int category_id { set; get; }
        public string img { set; get; }
        public string content { set; get; }
        public int? react_id { set; get; }
        public DateTime? date { set; get; }
    }
}
