using System;
using System.Collections.Generic;

namespace DiabetesAPI.Models
{
    public partial class Certificates
    {
        public int Id { get; set; }
        public string Certificate { get; set; }
        public string University { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
