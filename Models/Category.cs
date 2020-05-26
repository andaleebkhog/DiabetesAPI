using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Posts = new HashSet<Posts>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
